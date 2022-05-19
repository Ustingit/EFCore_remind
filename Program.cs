using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFCore2DBFirst
{
	class Program
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="args"></param>
		/// <returns></returns>
		static async Task Main(string[] args)
		{
			// Добавление
			// using (var db = new helloappContext())
			// {
			// 	User tom = new User { Name = "Tom", Age = 33, Company = new Company() { Id = 3, Name = "Epam" } };
			// 	User alice = new User { Name = "Alice", Age = 26 };
			//
			// 	// Добавление
			// 	await db.Users.AddRangeAsync(tom, alice);
			// 	db.SaveChanges();
			// }

			using (var db = new helloappContext())
			{
				Company company1 = new Company { Name = "Apple" };
			Company company2 = new Company { Name = "Forte" };
			db.Companies.AddRange(company1, company2);  // добавление компаний
			db.SaveChanges();

			User user1 = new User { Name = "Tom", CompanyId = company1.Id, Age = 23 };
			User user2 = new User { Name = "Bob", CompanyId = company1.Id, Age = 23 };
			User user3 = new User { Name = "Sam", CompanyId = company2.Id, Age = 23 };

			db.Users.AddRange(user1, user2, user3);     // добавление пользователей
			db.SaveChanges();
			}

			// получение
			using (var db = new helloappContext())
			{
				// получаем объекты из бд и выводим на консоль
				var users = db
					.Users
					.Include(x => x.Company) //eager loading of dependencies
					.ToList();

				Console.WriteLine("Данные после добавления:");
				foreach (User u in users)
				{
					Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}, {u.Company?.Name}");
				}
			}

			using (var db = new helloappContext())
			{
				// получаем первый объект
				var user = db.Users.FirstOrDefault();
				if (user != null)
				{
					user.Name = "Bob";
					user.Age = new Random().Next(12, 100);
					//обновляем объект
					db.Users.Update(user);
					await db.SaveChangesAsync();
				}

				// выводим данные после обновления
				Console.WriteLine("\nДанные после редактирования:");
				var users = db.Users.ToList();
				foreach (User u in users)
				{
					Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
				}
			}

			// Удаление
			/*using (var db = new helloappContext())
			{
				// получаем первый объект
				User? user = db.Users.FirstOrDefault();
				if (user != null)
				{
					//удаляем объект
					db.Users.Remove(user);
					await db.SaveChangesAsync();
				}
				// выводим данные после обновления
				Console.WriteLine("\nДанные после удаления:");
				var users = await db.Users.ToListAsync();
				foreach (User u in users)
				{
					Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}, {u.Company?.Name}");
				}
			}*/

			using (var db = new helloappContext())
			{
				var companies = await db.Companies.Include(x => x.Users).ToListAsync();

				foreach (var company in companies)
				{
					Console.WriteLine(company.Name);
				}
			}

			Console.WriteLine("Hello World!");

			Console.ReadLine();
		}
	}
}
