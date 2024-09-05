using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace urunrestapi
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; } // users tablosuna denk geliyor.
        public DbSet<Urun> Urunler { get; set; } // urunler tablosuna denk geliyor mysql üzerindeki. tablo adı ona göre belirlendi. dbset içerisindeki get set metodu ile ilk sütundan başlayarak alıyoruz değerleri.



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>()
                .HasKey(u => u.UrunBarkod); 
                                             // primary key tanımlamaları yapılıyor.
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);
        }

    }
}
