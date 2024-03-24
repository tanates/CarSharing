namespace CarSharing.Server.Interface.Car
{
    public interface ICheckingAccountStatus
    {
        public double GetRentalPrice(string price, DateTime dateStart, DateTime dateEnd);
        public bool IsAuthorizedAccount(HttpContext httpContext);
        public bool IsAvailableBalance(double userBalance, double allPriceTheCar);
        
        public double NewBalance(double userBalance, double allPriceTheCar);
    }
}
