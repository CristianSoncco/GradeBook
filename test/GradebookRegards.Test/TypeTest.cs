using System;
using Xunit;

namespace GradebookRegards.Test;

public delegate string WriteLogDelegate(string logMessage); 
public class TypeTest
{
    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log;
        log = ReturnMessage;


        var result = log("Hello!");
        Assert.Equal("Hello!", result);
    }

    string ReturnMessage(string message)
    {
        return message;
    }

    [Fact]
    public void ValueTypeAlsoPassByValue()
    {
        //arrange
        var x   =   GetInt();
        SetInt(ref x);
        //act

        //assert
        Assert.Equal(42, x);

    }

    private void SetInt(ref int z)
    {
        z = 42;
    }

    private int GetInt()
    {
        return 3;
    }
    [Fact]
    public void CSharpCanPassByRef()
    {
        //arrange
        var book1   =   GetBook("Book 1");
        GetBookSetName(out book1,"New Name");

        //act

        //assert
        Assert.Equal("New Name", book1.Name);

    }
    private void GetBookSetName(out Book book,string name)
    {
        book    =   new Book(name);
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        //arrange
        var book1   =   GetBook("Book 1");
        GetBookSetName(book1,"New Name");

        //act

        //assert
        Assert.Equal("Book 1", book1.Name);

    }
    private void GetBookSetName(Book book,string name)
    {
        book    =   new Book(name);
    }

    [Fact]
    public void CanSetNameFromReference()
    {
        //arrange
        var book1   =   GetBook("Book 1");
        SetName(book1,"New Name");

        //act

        //assert
        Assert.Equal("New Name", book1.Name);

    }

    private void SetName(Book book,string name)
    {
        book.Name   =   name;
    }


    [Fact]
    public void StringsBehaveLikeValueTypes()
    {
        string name = "Scott";
        var upper = MakeUpperCase(name);

        Assert.Equal("Scott",name);
        Assert.Equal("SCOTT",upper);
    }

    private string MakeUpperCase(string parameter)
    {
        return parameter.ToUpper();
    }

    [Fact]
    public void GetBookReturnDifferentObjects()
    {
        //arrange
        var book1   =   GetBook("Book 1");
        var book2   =   GetBook("Book 2");

        //act

        //assert
        Assert.Equal("Book 1",book1.Name);
        Assert.Equal("Book 2",book2.Name);
        Assert.NotSame(book1,book2);

    }

    [Fact]
    public void TwoVariablesCanReferenceSameObject()
    {
        //arrange
        var book1   =   GetBook("Book 1");
        var book2   =   book1;

        //act

        //assert
        Assert.Same(book1,book2);
        Assert.True(Object.ReferenceEquals(book1,book2));

    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}