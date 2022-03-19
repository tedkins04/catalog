using NUnit.Framework;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace NUnitTests
{
    public class MockDbSet
    {
        public static Mock<DbSet<T>> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            IQueryable<T> queryable = sourceList.AsQueryable();

            Mock<DbSet<T>> dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(x => x.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(x => x.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(x => x.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(x => x.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            dbSet.Setup(w => w.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            dbSet.Setup(w => w.Remove(It.IsAny<T>())).Callback<T>((s) => sourceList.Remove(s));
            dbSet.Setup(w => w.RemoveRange(It.IsAny<IEnumerable<T>>())).Callback((IEnumerable<T> x) => sourceList.RemoveAll(x.Contains));

            return dbSet;
        }
    }
}