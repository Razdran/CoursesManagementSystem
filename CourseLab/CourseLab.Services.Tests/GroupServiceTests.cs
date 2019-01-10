using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using FluentAssertions;
using CourseLab.Services.Services.Group;
using CourseLab.Data.UserManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Moq;
using Entities = CourseLab.Data.UserManagement.Entities;

namespace CourseLab.Services.Tests
{
    [TestClass]
    public class GroupServiceTests
    {
        private readonly Mock<IRepository<Entities.Group>> _groupRepository = new Mock<IRepository<Entities.Group>>();
        private readonly Mock<IUnitOfWork> _unitOfWork = new Mock<IUnitOfWork>();

        private Guid _validId = new Guid("feacf0cb-3c0f-476d-a04c-34da5421e0df");
        private Guid _invalidId = new Guid("34D2C9A8-D33D-4DE3-AF25-8A67D0F3A999");
        private Guid _default = new Guid ("00000000-0000-0000-0000-000000000000");

        private Data.UserManagement.GroupEnum _g = Data.UserManagement.GroupEnum.B1;
        private enum num {A};
        private Enum _invG = num.A;

        [TestMethod]
        public void GetById_ValidId()
        {
            var group = new GroupService(_groupRepository.Object, _unitOfWork.Object);
            _groupRepository.Setup(g => g.GetById(_validId)).Returns(new Entities.Group() { IsDeleted=false , Name = _g.ToString()});

            var result = group.GetbyId(_validId);

            result.Name.Should().BeEquivalentTo(_g.ToString());
        }

        [TestMethod]
        public void GetById_InvaidId()
        {
            var group = new GroupService(_groupRepository.Object, _unitOfWork.Object);
            _groupRepository.Setup(g => g.GetById(It.IsAny<Guid>())).Returns((Entities.Group)null);
            //getbyid la mapare NU poate fi null
            var result = group.GetbyId(_invalidId);
        
            result.Name.Should().BeNull();
        }

        [TestMethod]
        public void GetById_GroupDeleted()
        {
            var group = new GroupService(_groupRepository.Object, _unitOfWork.Object);
            _groupRepository.Setup(g => g.GetById(_validId)).Returns(new Entities.Group() { IsDeleted = true, Name = _g.ToString() });

            var result = group.GetbyId(_validId);

            result.Should().BeNull();
        }

        [TestMethod]
        public void GetByName_ValidName()
        {
        }

        [TestMethod]
        public void GetByName_InvalidName()
        {
        }


        [TestMethod]
        public void GetAll_AtLeatsOneGroupInDB()
        {
            var group = new GroupService(_groupRepository.Object, _unitOfWork.Object);

            var result = group.GetAll();

            result[0].Should().NotBeNull();
        }

    }
}
