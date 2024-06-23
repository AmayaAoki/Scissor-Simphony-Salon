using SiteASP.Interfaces;
using SiteASP.Models;

namespace SiteASP.Data.Repository
{
    public class ReviewsRepository : IAllReviews
    {
        // получаем все объекты
        public IEnumerable<Reviews> Reviews => appDBContent.Reviews;
        private readonly AppDBContent appDBContent;
        public ReviewsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        // один объект, где id = serviceid
        public Reviews getObjectServices(int ID)
        {
            // Получаем услугу по ее идентификатору
            var empp = appDBContent.Reviews.FirstOrDefault(s => s.Id == ID);
            // Проверяем, что услуга была найдена
            if (empp != null)
            {
                // Обрабатываем данные услуги, например, выводим на консоль
                Console.WriteLine($"ID: {empp.Id}, UserName: {empp.UserName}, UserPhoto: {empp.UserPhoto}, Header: {empp.Header}, UserText: {empp.Text}, UserPhoto: {empp.Checked}");
                return empp;
            }
            else
            {
                Console.WriteLine("Услуга не найдена");
                return new Reviews();
            }

            
        }
    }
}
