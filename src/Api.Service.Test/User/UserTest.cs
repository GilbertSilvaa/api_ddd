using Api.Domain.Dtos.User;

namespace Api.Service.Test.User
{
    public class UserTest
    {
        public static string NameUser { get; set; } = null!;
        public static string EmailUser { get; set; } = null!;
        public static string NameUserModified { get; set; } = null!;
        public static string EmailUserModified { get; set; } = null!;
        public static Guid IdUser { get; set; }

        public List<UserDto> userDtoList = new();
        public UserDto userDto;
        public UserCreateDto userCreateDto;
        public UserCreateResultDto userCreateResultDto;
        public UserUpdateDto userUpdateDto;
        public UserUpdateResultDto userUpdateResultDto;

        public UserTest()
        {
            IdUser = Guid.NewGuid();
            NameUser = Faker.Name.FullName();
            EmailUser = Faker.Internet.Email();
            NameUserModified = Faker.Name.FullName();
            EmailUserModified = Faker.Internet.Email();

            for (int i = 0; i < 10; i++)
            {
                UserDto _userDto = new()
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                userDtoList.Add(_userDto);
            }

            userDto = new UserDto
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userCreateDto = new UserCreateDto
            {
                Name = NameUser,
                Email = EmailUser
            };

            userCreateResultDto = new UserCreateResultDto
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                CreateAt = DateTime.UtcNow
            };

            userUpdateDto = new UserUpdateDto
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser
            };

            userUpdateResultDto = new UserUpdateResultDto
            {
                Id = IdUser,
                Name = NameUser,
                Email = EmailUser,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
