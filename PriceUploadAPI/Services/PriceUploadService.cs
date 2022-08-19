using PriceUploadAPI.Entities;
using PriceUploadAPI.Helpers;

namespace PriceUploadAPI.Services
{
    public interface IPriceUploadService
    {
        bool UploadPriceData(List<PriceUpload> objPriceDataList);
    }

    public class PriceUploadService : IPriceUploadService
    {
        private DataContext _context;

        public PriceUploadService(DataContext context)
        {
            _context = context;
        }

        public bool UploadPriceData(List<PriceUpload> objPriceDataList)
        {
            try
            {
                _context.PriceUpload.AddRange(objPriceDataList);
                _context.SaveChanges();
                return true;
            }
            catch (AppException ex)
            {
                throw ex;
            }
        }
    }
}
