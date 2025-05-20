using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReservationService.Models;
using TableService.Models.Models;

namespace ReservationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("TableService");
        }

        [HttpPost("reservation")]
        public async Task<IActionResult> MakeReservation([FromBody] ReservationRequestModel reservation)
        {
            var request = await _httpClient.GetAsync("http://localhost:5021/api/Table/tables");
            var content = await request.Content.ReadAsStringAsync();

            var availableTables = JsonSerializer
            .Deserialize<List<TableModel>>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var selectTable = availableTables?.FirstOrDefault(table =>
                table.Available &&
                reservation.Preferences.Contains(table.Location));

            if (selectTable is not null)
            {
                var json = JsonSerializer.Serialize(selectTable);
                var contentSerialized = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"http://localhost:5021/api/Table/table/{selectTable.TableId}", contentSerialized);

                if (!response.IsSuccessStatusCode)
                {
                    // Handle error
                    var errorContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to update table: {errorContent}");
                }

                var reservationResponse = new ReservationResponseModel
                {
                    ReservationId = reservation.CustomerId + reservation.TableId,
                    Status = "Reserved",
                    TableId = selectTable.TableId,
                    WaitlistMessage = "No need to Wait"
                };

                return Ok(reservationResponse);
            }
            else
            {
                var waitingTable = availableTables?.FirstOrDefault(table =>
                reservation.Preferences.Contains(table.Location));

                return Ok(new ReservationResponseModel
                {
                    ReservationId = reservation.CustomerId + reservation.TableId,
                    Status = "Reserved",
                    TableId = waitingTable.TableId,
                    WaitlistMessage = "You have been put on the waiting list"
                });

            }
        }

    }
}
