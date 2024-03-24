using CarSharing.Server.Interface.Car;
using CarSharing.Server.Models.UserModels;
using System.Diagnostics.CodeAnalysis;

namespace CarSharing.Server
{
    public class CheckingAccountStatus : ICheckingAccountStatus
    {
        public double GetRentalPrice(string price , DateTime dateStart , DateTime dateEnd) 
        {

            if (price == null ||dateEnd == DateTime.MinValue ||dateEnd ==DateTime.MinValue) 
            {
                throw new Exception("Первичные значения пусты");
            }

           TimeSpan timeSpan = dateEnd - dateStart;

           double result = timeSpan.TotalHours * Convert.ToDouble(price);
            return result;
        }

        public bool IsAuthorizedAccount(HttpContext httpContext)
        {
            if (!httpContext.User.Identity.IsAuthenticated) 
            {
                return false;
            }

            return true;
        }
        public bool IsAvailableBalance(double userBalance , double allPriceTheCar) 
        {
            var result = userBalance >=allPriceTheCar ? true : false;
            return result;
        }

        public double NewBalance(double userBalance , double price)
        {
            double balance = userBalance - price;
            var result = balance < 0 ? throw new Exception("Баланс не может быть отрицательным") : balance;
            return result;
        }
    }
}
