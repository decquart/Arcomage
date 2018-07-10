using AutoMapper;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace BLL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        IScoreService _scoreService;
        private IServiceProvider serviceProvider;

        public UnitTest1(IScoreService scoreService)
        {
            
        }

        

        [TestMethod]
        public void UnitTest_IsThrowExIfUserNotFound()
        {            
            //Assert.ThrowsException<ArgumentException>(() => service.);
        }

    }

}

   



