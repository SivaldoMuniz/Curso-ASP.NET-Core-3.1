using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Test.Usuario;
using Moq;
using Xunit;

namespace Api.Service.Test
{
    public class QuandoForExecutadoGet : UsuarioTestes
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "È Possivel Executar o Método GET.")]
        public async Task E_Possivel_Executar_Metodo_Get()
        {
            {
                //Given
                _serviceMock = new Mock<IUserService>();
                _serviceMock.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
                _service = _serviceMock.Object;

                //When
                var result = await _service.Get(IdUsuario);
                Assert.NotNull(result);
                Assert.True(result.Id == IdUsuario);
                Assert.Equal(NomeUsuario, result.Name);

                //Then

                _serviceMock = new Mock<IUserService>();
                _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
                _service = _serviceMock.Object;

                var _record = await _service.Get(IdUsuario);
                Assert.Null(_record);
            }

        }
    }
}
