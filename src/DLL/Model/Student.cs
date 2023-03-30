namespace DLL.Model
{
    public class Student
    {
        public int StudentId  {get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        //dotnet ef migrations add InitialMigration --project "DLL" --startup-project "API"
        // dotnet ef database update --project "DLL" --startup-project "API"

    }
}