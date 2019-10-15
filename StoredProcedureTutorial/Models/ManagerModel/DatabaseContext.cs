using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StoredProcedureTutorial.Models.ManagerModel
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Book> Books { get; set; }


        //Database modeli oluşturulurken yapılacak bazı tanımlamalar
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .MapToStoredProcedures(config => {
                    config.Insert(i => i.HasName("BookInsertSP"));
                    config.Update(u => {
                        u.HasName("BookUpdateSP");
                        u.Parameter(p => p.Id, "bookId");
                    });
                    config.Delete(d => d.HasName("BookDeleteSP"));
                });
        }
    }
}