using AnılBurakYamaner_Proje.Common.Dtos.User;

namespace AnılBurakYamaner_Proje.Common.WorkContext
{
    public interface IWorkContext
    {
        UserResponseDto CurrentUser { get; set; }
    }
}
