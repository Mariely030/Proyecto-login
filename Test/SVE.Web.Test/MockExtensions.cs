using Moq;
using System;
using System.Linq.Expressions;

namespace SVE.Web.Test
{
    public static class MockExtensions
    {
        // Para métodos que retornan algo
        public static Mock<T> SetupAny<T, TResult>(
            this Mock<T> mock,
            Expression<Func<T, TResult>> expression,
            TResult value)
            where T : class
        {
            mock.Setup(expression).Returns(value);
            return mock;
        }

        // Para métodos void
        public static Mock<T> SetupAny<T>(
            this Mock<T> mock,
            Expression<Action<T>> expression)
            where T : class
        {
            mock.Setup(expression);
            return mock;
        }
    }
}




