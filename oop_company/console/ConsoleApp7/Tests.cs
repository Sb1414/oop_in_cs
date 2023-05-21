using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Assert = Xunit.Assert;

namespace ConsoleApp7
{
    public class ApartmentTests
    {
        [Test]
        public void AddApartment_ShouldAddApartmentToList()
        {
            ApartmentsList apartmentsList = new ApartmentsList(3);
            Apartment apartment1 = new Apartment(1, 10000);
            Apartment apartment2 = new Apartment(2, 15000);

            apartmentsList.AddApartment(apartment1);
            apartmentsList.AddApartment(apartment2);

            NUnit.Framework.Assert.AreEqual(apartment1, apartmentsList.FindApartment(1));
            NUnit.Framework.Assert.AreEqual(apartment2, apartmentsList.FindApartment(2));
        }

        [Fact]
        public void AddNewApartmentTest()
        {
            Apartment apartment = new Apartment(1, 5000);

            int expectedPayment = 5000;
            int actualPayment = apartment.Payment;

            Assert.Equal(expectedPayment, actualPayment);
        }

        [Fact]
        public void AddApartmentExceedLimitTest()
        {
            House house = new House("Пушкина", 10, 2);
            house.AddApart(1, 5000);
            house.AddApart(2, 6000);

            Assert.Throws<InvalidOperationException>(() => house.AddApart(3, 4000));
        }

        [Fact]
        public void DeleteApartmentTest()
        {
            House house = new House("Пушкина", 10, 2);
            house.AddApart(1, 5000);
            house.AddApart(2, 6000);

            house.DelApart(2);

            Assert.Equal(1, house.SizeApart);
        }

        [Test]
        public void Test_DelApart_Failure()
        {
            // Arrange
            House house = new House("Some Street", 1, 3);

            house.AddApart(1, 100);

            Assert.Throws<Exception>(() => house.DelApart(2));
        }
    }

    public class HouseTests
    {
        [Test]
        public void TestHouseConstructor()
        {
            House house = new House("ул. Ленина", 5, 10);
            NUnit.Framework.Assert.AreEqual(10, house.SizeApart);
        }

        [Fact]
        public void CreateHouseTest()
        {
            House house = new House("Пушкина", 10, 2);

            string expectedAdressStreet = "Пушкина 10";
            int expectedSizeApart = 2;

            Assert.Equal(expectedAdressStreet, house.AdressStreet);
            Assert.Equal(expectedSizeApart, house.SizeApart);
        }

        [Fact]
        public void AddAndDeleteApartmentTest()
        {
            House house = new House("Пушкина", 10, 2);
            house.AddApart(1, 5000);
            house.AddApart(2, 6000);

            house.DelApart(2);
            house.AddApart(3, 4000);

            Assert.Equal(2, house.apartmentsList.GetCount());

            House house2 = new House("ул. Ленина", 5, 10);
            house2.AddApart(1, 10000);
            NUnit.Framework.Assert.AreEqual(1, house2.apartmentsList.GetCount());
            NUnit.Framework.Assert.AreEqual(10000, house2.SearchApartment(1).Payment);
        }
    }

    public class ManagementCompanyTests
    {
        [Fact]
        public void AddHouseTest()
        {
            ManagementCompany company = new ManagementCompany();

            company.AddHouse("Пушкина", 10, 2);
            company.AddHouse("Спартаковская", 5, 3);

            Assert.NotNull(company.SearchHouse("Пушкина", 10));
            Assert.NotNull(company.SearchHouse("Спартаковская", 5));
        }

        [Fact]
        public void DeleteHouseTest()
        {
            ManagementCompany company = new ManagementCompany();
            company.AddHouse("Пушкина", 10, 2);
            company.AddHouse("Спартаковская", 5, 3);

            company.DelHouse();

            Assert.Equal(1, company.CountHouse);
        }

        [Fact]
        public void SearchHouseTest()
        {
            ManagementCompany company = new ManagementCompany();
            company.AddHouse("Пушкина", 10, 2);
            company.AddHouse("Спартаковская", 5, 3);

            House house = company.SearchHouse("Пушкина", 10);

            Assert.NotNull(house);
            Assert.Equal("Пушкина 10", house.AdressStreet);
        }
    }
}
