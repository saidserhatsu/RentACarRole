namespace Core.Entities
{
    public class Role : Entity<int>
    {
        public string RoleName { get; set; }

        public ICollection<User>? UserList { get; set; }
        
    
    }
}
//Update-Database AddUser
//Remove-Migration
