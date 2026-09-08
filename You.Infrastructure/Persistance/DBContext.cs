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
}