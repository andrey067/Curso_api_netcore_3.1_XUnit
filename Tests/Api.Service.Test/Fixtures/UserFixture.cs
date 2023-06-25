using Api.Domain.Entities;
using Application.Dtos.Users;
using Bogus;

namespace Application.Test.Fixtures
{
    public static class UserFixture
    {
        public static User UserEntitie()
        {
            var _faker = new Faker();

            return new User(_faker.Person.FullName, _faker.Person.Email);
        }

        public static CreateUserDto CreateUserDto()
        {
            var _faker = new Faker();

            return new CreateUserDto(_faker.Person.FullName, _faker.Person.Email);
        }
        public static UpdateUserDto UpdateUserDto()
        {
            var _faker = new Faker();

            return new UpdateUserDto(_faker.IndexFaker, _faker.Person.FullName, _faker.Person.Email);
        }
    }
}
