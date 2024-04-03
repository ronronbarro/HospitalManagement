namespace HospitalManagement.Shared.Entities
{
    public class Hospital
    {
        public int Id { get; set; }
        public string? Hospital_Id { get; set; }
        public string? Name { get; set; }
        public bool Is_Active { get; set; }
        public int Account_Manager { get; set; }
        public string? Plan_Assigned { get; set; }

    }
}
