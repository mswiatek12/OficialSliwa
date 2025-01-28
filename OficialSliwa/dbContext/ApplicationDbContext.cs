using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.AppUser;
using OficialSliwa.dbContext;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace OficialSliwa.dbContext.ApplicationDbContext
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<Czlonkostwo> Czlonkostwa { get; set; }
        public DbSet<Uraz> Urazy { get; set; }
        public DbSet<Statystyki> Statystyki { get; set; }
        public DbSet<NajlepsiZawodnicy> NajlepsiZawodnicy { get; set; }
        public DbSet<Sesja> Sesja { get; set; }
        public DbSet<WieleUrazow> WieleUrazow { get; set; }
        public DbSet<AktywneUrazyViewModel> AktywneUrazy { get; set; }
        public DbSet<AktywneCzlonkostwaViewModel> AktywneCzlonkostwa { get; set; }
        public DbSet<ObecnoscSesji> ObecnoscSesji { get; set; }
        public DbSet<StatystykiUzytkownika> StatystykiUzytkownika { get; set; }
        public DbSet<Zawodnicy> Zawodnicy { get; set; }
        public DbSet<NajaktywniejsiZawodnicy> NajaktywniejsiZawodnicy { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityRole<int>>().ToTable("AspNetRoles");
            modelBuilder.Entity<IdentityUser<int>>().ToTable("AspNetUsers");
            modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("AspNetUserClaims");
            modelBuilder.Entity<IdentityUserRole<int>>().ToTable("AspNetUserRoles");
            modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("AspNetUserLogins");
            modelBuilder.Entity<IdentityRoleClaim<int>>().ToTable("AspNetRoleClaims");
            modelBuilder.Entity<IdentityUserToken<int>>().ToTable("AspNetUserTokens");
            modelBuilder.Entity<IdentityUser<int>>().ToTable("AspNetUsers");
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(u => u.Id).HasColumnName("user_id");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.Imie).HasColumnName("imie");
                entity.Property(u => u.Password).HasColumnName("password");
                entity.Property(u => u.Nazwisko).HasColumnName("nazwisko");
                entity.Property(u => u.Rola).HasColumnName("rola");
                entity.Property(u => u.DataRejestracji).HasColumnName("data_rejestracji");
                entity.Property(u => u.OpuszczoneZajecia).HasColumnName("opuszczone_zajęcia");
            });
            modelBuilder.Entity<StatystykiUzytkownika>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("statystyki_uzytkownika");
                entity.Property(u => u.UserId).HasColumnName("user_id");
                entity.Property(u => u.Imie).HasColumnName("imie");
                entity.Property(u => u.Nazwisko).HasColumnName("nazwisko");
                entity.Property(u => u.Walki).HasColumnName("walki");
                entity.Property(u => u.Wygrane).HasColumnName("wygrane");
                entity.Property(u => u.Przegrane).HasColumnName("przegrane");
                entity.Property(u => u.Osiągnięcia).HasColumnName("osiągnięcia");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.Property(u => u.ConcurrencyStamp).HasColumnName("ConcurrencyStamp");
                entity.Property(u => u.AccessFailedCount).HasColumnName("AccessFailedCount");
                entity.Property(u => u.Id).HasColumnName("user_id");
                entity.Property(u => u.Email).HasColumnName("email");
                entity.Property(u => u.Imie).HasColumnName("imie");
                entity.Property(u => u.Password).HasColumnName("password");
                entity.Property(u => u.Nazwisko).HasColumnName("nazwisko");
                entity.Property(u => u.Rola).HasColumnName("rola");
                entity.Property(u => u.DataRejestracji).HasColumnName("data_rejestracji");
                entity.Property(u => u.OpuszczoneZajecia).HasColumnName("opuszczone_zajęcia");
            });

            modelBuilder.Entity<Statystyki>().ToTable("statystyki");
            modelBuilder.Entity<Czlonkostwo>().ToTable("czlonkostwo");
            modelBuilder.Entity<Uraz>().ToTable("urazy");
            modelBuilder.Entity<Sesja>().ToTable("sesje");
            modelBuilder.Entity<ObecnoscSesji>().ToTable("obecnosc_sesji");

            // Statistics configuration
            modelBuilder.Entity<Statystyki>()
                .HasKey(s => s.StatystykiId);
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.StatystykiId)
                .HasColumnName("statystyki_id");
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.Walki)
                .HasColumnName("walki");
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.UserId)
                .HasColumnName("wygrane");
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.UserId)
                .HasColumnName("przegrane");
            modelBuilder.Entity<Statystyki>()
                .Property(s => s.UserId)
                .HasColumnName("osiągnięcia");
            modelBuilder.Entity<Statystyki>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Membership configuration
            modelBuilder.Entity<Czlonkostwo>()
                .HasKey(m => m.CzlonkostwoId);
            modelBuilder.Entity<Czlonkostwo>()
                .Property(m => m.CzlonkostwoId)
                .HasColumnName("czlonkostwo_id");
            modelBuilder.Entity<Czlonkostwo>()
                .Property(m => m.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Czlonkostwo>()
                .Property(m => m.StartData)
                .HasColumnName("start_data");
            modelBuilder.Entity<Czlonkostwo>()
                .Property(m => m.KoniecData)
                .HasColumnName("koniec_data");
            modelBuilder.Entity<Czlonkostwo>()
                .Property(m => m.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Czlonkostwo>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Injuries configuration
            modelBuilder.Entity<Uraz>()
                .HasKey(i => i.UrazId);
            modelBuilder.Entity<Uraz>()
                .Property(i => i.UrazId)
                .HasColumnName("uraz_id");
            modelBuilder.Entity<Uraz>()
                .Property(i => i.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<Uraz>()
                .Property(i => i.UrazData)
                .HasColumnName("uraz_data");
            modelBuilder.Entity<Uraz>()
                .Property(i => i.Opis)
                .HasColumnName("opis");
            modelBuilder.Entity<Uraz>()
                .Property(i => i.Status)
                .HasColumnName("status");
            modelBuilder.Entity<Uraz>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(i => i.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Sessions configuration
            modelBuilder.Entity<Sesja>()
                .HasKey(s => s.SesjaId);
            modelBuilder.Entity<Sesja>()
                .Property(s => s.SesjaId)
                .HasColumnName("sesja_id");
            modelBuilder.Entity<Sesja>()
                .Property(s => s.SesjaData)
                .HasColumnName("sesja_data");
            modelBuilder.Entity<Sesja>()
                .Property(s => s.StartGodzina)
                .HasColumnName("start_godzina");
            modelBuilder.Entity<Sesja>()
                .Property(s => s.SesjaNazwa)
                .HasColumnName("sesja_nazwa");

            // SessionAttendance configuration
            modelBuilder.Entity<ObecnoscSesji>()
                .HasKey(sa => sa.SesjaObecnoscId);
            modelBuilder.Entity<ObecnoscSesji>()
                .Property(sa => sa.SesjaObecnoscId)
                .HasColumnName("obecnosc_sesji_id");
            modelBuilder.Entity<ObecnoscSesji>()
                .Property(sa => sa.SesjaId)
                .HasColumnName("sesja_id");
            modelBuilder.Entity<ObecnoscSesji>()
                .Property(sa => sa.UserId)
                .HasColumnName("user_id");
            modelBuilder.Entity<ObecnoscSesji>()
                .HasOne<Sesja>()
                .WithMany()
                .HasForeignKey(sa => sa.SesjaId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ObecnoscSesji>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(sa => sa.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //VIEW FOR PARTICIPANT
            modelBuilder.Entity<Zawodnicy>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("zawodnicy");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.Nazwisko).HasColumnName("nazwisko");
                entity.Property(p => p.Email).HasColumnName("email");
            });
            modelBuilder.Entity<AktywneUrazyViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("aktywne_urazy");
                entity.Property(p => p.UrazId).HasColumnName("uraz_id");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.Nazwisko).HasColumnName("nazwisko");
                entity.Property(p => p.UrazData).HasColumnName("uraz_data");
                entity.Property(p => p.Opis).HasColumnName("opis");
            });

            modelBuilder.Entity<AktywneCzlonkostwaViewModel>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("aktywne_czlonkostwa");
                entity.Property(p => p.CzlonkostwoId).HasColumnName("czlonkostwo_id");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.StartData).HasColumnName("start_data");
                entity.Property(p => p.KoniecData).HasColumnName("koniec_data");
            });

            modelBuilder.Entity<NajaktywniejsiZawodnicy>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("najaktywniejsi_zawodnicy");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.LiczbaObecnosci).HasColumnName("liczba_obecnosci");
            });

            modelBuilder.Entity<WieleUrazow>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("wiele_urazow");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.Nazwisko).HasColumnName("nazwisko");
                entity.Property(p => p.LiczbaUrazow).HasColumnName("liczba_urazow");
            });
            modelBuilder.Entity<NajlepsiZawodnicy>(entity =>
            {
                entity.HasNoKey();
                entity.ToView("user_wygrane_procent");
                entity.Property(p => p.UserId).HasColumnName("user_id");
                entity.Property(p => p.Imie).HasColumnName("imie");
                entity.Property(p => p.Nazwisko).HasColumnName("nazwisko");
                entity.Property(p => p.Wygrane).HasColumnName("wygrane");
                entity.Property(p => p.Walki).HasColumnName("walki");
                entity.Property(p => p.WygraneProcent).HasColumnName("wygrane_procent");
            });
        }
    }
}
