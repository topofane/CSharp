using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string LogMessageDelegate(string logMessage);


    public class TypeTests
    {
        [Fact]
        public void WritePointDelegateCanPointToMethod()
        {
            LogMessageDelegate log = ReturnMessage;

            //log = new LogMessageDelegate(ReturnMessage);
            log += IncrementCount;

            var result = log("Hello!");

            Assert.Equal("Hello!",result);
        }

        int count = 0;

        string IncrementCount(string message)
        {
            count += 1;
            return count.ToString();
        }

        string ReturnMessage(string message)
        {
            return message;
        }

        [Fact]
        public void StringsBehaveAsValueTypes()
        {
            string name = "Stefan";
            string upper = MakeUppercase(name);

            Assert.Equal("Stefan",name);
            Assert.Equal("STEFAN",upper);
        }

        public string MakeUppercase(string paramenter)
        {
            return paramenter.ToUpper();
        }

        [Fact]
        public void Test1()
        {
            var x = GetInteger();
            SetInt(ref x);

            Assert.Equal(42,x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInteger()
        {
            return 3;
        }

        [Fact]
        public void CSharpICanPassByRef()
        {
            //Arrange
            var book1 = GetBook("book1");
            GetBookSetName(ref book1, "new Name");
            //Act
            //var result = book.GetStatistics();
            
            //Assert
            Assert.Equal("new Name", book1.Name);
        }

        private void GetBookSetName(ref Book book, string newName)
        {
            book = new Book(newName);
        }

        
        [Fact]
        public void CSharpIsPassByValue()
        {
            //Arrange
            var book1 = GetBook("book1");
            GetBookSetName(book1, "new Name");
            //Act
            //var result = book.GetStatistics();
            
            //Assert
            Assert.Equal("book1", book1.Name);
        }

        private void GetBookSetName(Book book, string newName)
        {
            book = new Book(newName);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            //Arrange
            var book1 = GetBook("book1");
            NewName(book1, "new Name");
            //Act
            //var result = book.GetStatistics();
            
            //Assert
            Assert.Equal("new Name", book1.Name);
        }

        private void NewName(Book book, string newName)
        {
            book.Name = newName;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arrange
            var book1 = GetBook("book1");
            var book2 = GetBook("book2");

            //Act
            //var result = book.GetStatistics();
            
            //Assert
            Assert.Equal("book1", book1.Name);
            Assert.Equal("book2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //Arrange
            var book1 = GetBook("book1");
            var book2 = book1;

            //Act
            //var result = book.GetStatistics();
            
            //Assert
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1,book2));
            //Assert.Equal("book1", book2.Name);
        }

        private Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
