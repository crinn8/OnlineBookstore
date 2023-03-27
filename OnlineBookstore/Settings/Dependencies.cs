using OnlineBookstore.Repository;
using OnlineBookstore.Services;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Settings
{
    public static class Dependencies
    {
        #region Private Methods
        private static void AddServices(IServiceCollection services)
        {
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IBooksStockService, BooksStockService>();
            services.AddTransient<IBookStoreService, BookStoreService>();
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBooksStockRepository, BooksStockRepository>();
            services.AddTransient<IBookStoreRepository, BookStoreRepository>();
        }
        #endregion

        #region Public Methods
        public static void Inject(WebApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Services.AddControllers();
            applicationBuilder.Services.AddSwaggerGen();

            applicationBuilder.Services.AddDbContext<AppDBContext>(options =>
            {
                options.UseSqlServer(applicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            AddRepositories(applicationBuilder.Services);
            AddServices(applicationBuilder.Services);
        }
        #endregion
    }
}
