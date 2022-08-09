namespace Factory.Models
{
  public class MachineEngineer
  {       
    public int MachineId { get; set; }
    public int EngineerId { get; set; }
    public int MachineEngineer { get; set; }
    public virtual Engineer Engineer { get; set; }
    public virtual Machine Machine { get; set; }
  }
}