using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PriceUploadAPI.Entities;
using PriceUploadAPI.Helpers;
using PriceUploadAPI.Services;
using System.Text;

namespace PriceUploadAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PriceUploadController : ControllerBase
    {
        private IPriceUploadService _priceUploadService;

        public PriceUploadController(IPriceUploadService priceUploadService)
        {
            _priceUploadService = priceUploadService;
        }


        [AllowAnonymous]
        [HttpPost, DisableRequestSizeLimit]
        public IActionResult UploadPriceData(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    if (file.FileName.EndsWith(".xls") || file.FileName.EndsWith(".xlsx"))
                    {
                        List<PriceUpload> objData = new List<PriceUpload>();
                        Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                        using (var stream = new MemoryStream())
                        {
                            file.CopyTo(stream);
                            stream.Position = 0;
                            using (var reader = ExcelReaderFactory.CreateReader(stream))
                            {
                                while (reader.Read())
                                {
                                    objData.Add(new PriceUpload
                                    {
                                        Mit = reader.GetValue(0).ToString(),
                                        Code = reader.GetValue(1).ToString(),
                                        CurrencyCode = reader.GetValue(2).ToString(),
                                        Subscription = Convert.ToInt64(reader.GetValue(3)),
                                        Redemption = Convert.ToInt64(reader.GetValue(4)),
                                        Expense = Convert.ToInt64(reader.GetValue(5)),
                                        Net = Convert.ToInt64(reader.GetValue(6))
                                    });
                                }
                            }

                            if (_priceUploadService.UploadPriceData(objData))
                            {
                                return Ok("Data Uploaded Successfully");
                            }
                            else
                            {
                                return StatusCode(500, $"Internal server error occurred");
                            }
                        }
                    }
                    else
                    {
                        return BadRequest("Invalid File");
                    }
                }
                else
                {
                    return BadRequest("Empty File");
                }
            }
            catch (AppException ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
