﻿using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Demo.Domain.Repositories
{
	public abstract class RepositoryBase<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
		where TEntity : class, IIEntity<TPrimaryKey>
	{		
		public int Count()
		{
			return GetAll().Count();
		}

		public int Count(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).Count();
		}

		public virtual Task<int> CountAsync()
		{
			return Task.FromResult(Count());
		}

		public Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(Count(predicate));
		}

		public abstract void Delete(TPrimaryKey id);

		public virtual void Delete(Expression<Func<TEntity, bool>> predicate)
		{
			foreach (var entity in GetAll().Where(predicate).ToList())
			{
				Delete(entity);
			}
		}

		public abstract void Delete(TEntity entity);

		public virtual async Task DeleteAsync(Expression<Func<TEntity, bool>> predicate)
		{
			Delete(predicate);
		}

		public virtual Task DeleteAsync(TPrimaryKey id)
		{
			Delete(id);
			return Task.FromResult(0);
		}

		public Task DeleteAsync(TEntity entity)
		{
			Delete(entity);
			return Task.FromResult(0);
		}

		public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().FirstOrDefault(predicate);
		}

		public TEntity FirstOrDefault(TPrimaryKey id)
		{
			return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
		}

		public virtual Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(FirstOrDefault(predicate));
		}

		public virtual Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
		{
			return Task.FromResult(FirstOrDefault(id));
		}

		public virtual TEntity Get(TPrimaryKey id)
		{
			var entity = FirstOrDefault(id);
			if(entity == null)
			{
				throw new EntityNotFoundException(typeof(TEntity), id);
			}

			return entity;
		}

		public abstract IQueryable<TEntity> GetAll();

		public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors)
		{
			return GetAll();
		}

		public virtual List<TEntity> GetAllList()
		{
			return GetAll().ToList();
		}

		public virtual List<TEntity> GetAllList(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).ToList();
		}

		public virtual Task<List<TEntity>> GetAllListAsync()
		{
			return Task.FromResult(GetAllList());
		}

		public virtual Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(GetAllList(predicate));
		}

		public virtual async Task<TEntity> GetAsync(TPrimaryKey id)
		{
			var entity = await FirstOrDefaultAsync(id);
			if(entity == null)
			{
				throw new EntityNotFoundException(typeof(TEntity), id);
			}

			return entity;
		}

		public abstract TEntity Insert(TEntity entity);

		public virtual TPrimaryKey InsertAndGetId(TEntity entity)
		{
			return Insert(entity).Id;
		}

		public virtual Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
		{
			return Task.FromResult(InsertAndGetId(entity));
		}

		public virtual Task<TEntity> InsertAsync(TEntity entity)
		{
			return Task.FromResult(Insert(entity));
		}

		public virtual TEntity InsertOrUpdate(TEntity entity)
		{
			return entity.IsTransient()
				? Insert(entity)
				: Update(entity);
		}

		public virtual TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
		{
			return InsertOrUpdate(entity).Id;
		}

		public virtual Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
		{
			return Task.FromResult(InsertOrUpdateAndGetId(entity));
		}

		public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
		{
			return entity.IsTransient()
				? await InsertAsync(entity)
				: await UpdateAsync(entity);
		}

		public virtual TEntity Load(TPrimaryKey id)
		{
			return Get(id);
		}

		public virtual Task<long> LongAsync()
		{
			return Task.FromResult(LongCount());
		}

		public virtual long LongCount()
		{
			return GetAll().LongCount();
		}

		public virtual long LongCount(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Where(predicate).LongCount();
		}

		public Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(LongCount(predicate));
		}

		public virtual T Query<T>(Func<IQueryable<TEntity>, T> queryMethod)
		{
			return queryMethod(GetAll());
		}

		public virtual TEntity Single(Expression<Func<TEntity, bool>> predicate)
		{
			return GetAll().Single(predicate);
		}

		public Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return Task.FromResult(Single(predicate));
		}

		public abstract TEntity Update(TEntity entity);

		public virtual TEntity Update(TPrimaryKey id, Action<TEntity> updateAction)
		{
			var entity = Get(id);
			updateAction(entity);
			return entity;
		}

		public virtual Task<TEntity> UpdateAsync(TEntity entity)
		{
			return Task.FromResult(Update(entity));
		}

		public virtual async Task<TEntity> UpdateAsync(TPrimaryKey id, Action<TEntity> updateAction)
		{
			var entity = await GetAsync(id);
			updateAction(entity);
			return entity;
		}

		protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
		{
			var lambdaParam = Expression.Parameter(typeof(TEntity));

			var lambdaBody = Expression.Equal(
				Expression.PropertyOrField(lambdaParam, "Id"),
				Expression.Constant(id, typeof(TPrimaryKey))
				);

			return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
		}
	}
}
