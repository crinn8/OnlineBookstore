using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore
{
    public partial class AppDBContext : DbContext
    {
        #region Properties
        public virtual DbSet<BooksStock> BooksStocks { get; set; }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<BookStore> BookStores { get; set; }
        #endregion

        #region Constructors
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BooksStock>(entity =>
            {
                entity.ToTable("BooksStock");

                entity.Property(e => e.BookId).HasColumnName("bookId");
                entity.Property(e => e.BookStoreId).HasColumnName("bookStoreId");

                entity.HasOne(d => d.Book).WithMany(p => p.BooksStocks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksStock_Book");

                entity.HasOne(d => d.Book).WithMany(p => p.BooksStocks)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BooksStock_BookStore");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Book");

                entity.Property(e => e.Author).HasMaxLength(50);
                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<BookStore>(entity =>
            {
                entity.ToTable("BookStore");

                entity.Property(e => e.Address).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
