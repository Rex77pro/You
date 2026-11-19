using Microsoft.EntityFrameworkCore;
using You.Domain.Entities;

namespace You.Infrastructure.Persistence;

public class YouDbContext: DbContext
{
    public DbSet<DayExercise> DayExercises { get; set; }
    public DbSet<ExerciseSet> ExerciseSets { get; set; }
    public DbSet<ExerciseVariant> ExerciseVariants { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<GripType> GripTypes { get; set; }
    public DbSet<WeightType> WeightTypes { get; set; }

    public YouDbContext(DbContextOptions<YouDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ExerciseVariant>()
            .HasOne(v => v.Exercise)
            .WithMany()
            .HasForeignKey(v => v.ExerciseId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        modelBuilder.Entity<ExerciseVariant>()
            .HasOne(v => v.GripType)
            .WithMany()
            .HasForeignKey(v => v.GripTypeId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<ExerciseVariant>()
            .HasOne(v => v.WeightType)
            .WithMany()
            .HasForeignKey(v => v.WeightTypeId)
            .OnDelete(DeleteBehavior.ClientNoAction);
        
        modelBuilder.Entity<ExerciseVariant>()
            .HasIndex(v => new
            {
                v.ExerciseId,
                v.GripTypeId,
                v.WeightTypeId
            })
            .IsUnique()
            .AreNullsDistinct(false)
            .HasDatabaseName(
                "IX_ExerciseVariants_ExerciseId_GripTypeId_WeightTypeId"
            );

        modelBuilder.Entity<DayExercise>()
            .HasOne(d => d.ExerciseVariant)
            .WithMany(v => v.DayExercises)
            .HasForeignKey(d => d.ExerciseVariantId)
            .OnDelete(DeleteBehavior.ClientNoAction);

        modelBuilder.Entity<ExerciseSet>()
            .HasOne(s => s.DayExercise)
            .WithMany(d => d.Sets)
            .HasForeignKey(s => s.DayExerciseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}