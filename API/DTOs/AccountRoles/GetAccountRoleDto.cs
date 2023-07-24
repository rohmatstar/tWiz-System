namespace API.DTOs.AccountRoles
{
    public class GetAccountRoleDto
    {
        public Guid Guid { get; set; }
        public Guid AccountGuid { get; set; }
        public Guid RoleGuid { get; set; }
    }
}
