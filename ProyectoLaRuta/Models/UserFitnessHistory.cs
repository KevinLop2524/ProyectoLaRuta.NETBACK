using System;
using System.Collections.Generic;

namespace ProyectoLaRuta.Models;

public partial class UserFitnessHistory
{
    public long Id { get; set; }

    public double? ArmMeasurement { get; set; }

    public double? BodyFatPercentage { get; set; }

    public double? ChestMeasurement { get; set; }

    public double? HipMeasurement { get; set; }

    public DateOnly? RecordDate { get; set; }

    public double? ThighMeasurement { get; set; }

    public double? WaistMeasurement { get; set; }

    public double? Weight { get; set; }

    public long? UserId { get; set; }

    public virtual User? User { get; set; }
}
