using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Grupo4
{
    class Clases
    {
		/*
		/-******* CLASE MYCONTEXT *******-/

		using Microsoft.EntityFrameworkCore;

		public DbSet<Usuario> usuarios { get; set; }
		public MyContext() { }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(Properties.Resources.ConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//nombre de la tabla
			modelBuilder.Entity<Usuario>()
				.ToTable("Usuarios")
				.HasKey(u => u.id);
			//propiedades de los datos
			modelBuilder.Entity<Usuario>(
				usr =>
				{
					usr.Property(u => u.dni).HasColumnType("int");
					usr.Property(u => u.dni).IsRequired(true);
					usr.Property(u => u.nombre).HasColumnType("varchar(50)");
					usr.Property(u => u.mail).HasColumnType("varchar(50)");
					usr.Property(u => u.password).HasColumnType("varchar(50)");
					usr.Property(u => u.esAdmin).HasColumnType("bit");
					usr.Property(u => u.bloqueado).HasColumnType("bit");
				});
			//Ignoro, no agrego UsuarioManager a la base de datos
			modelBuilder.Ignore<UsuarioManager>();
		}


		/-******* CLASE USUARIO *******-/

		public int num_usr { get; set; }
		public int dni { get; set; }
		public string nombre { get; set; }
		public string mail { get; set; }
		public string password { get; set; }
		public bool esAdmin { get; set; }
		public bool bloqueado { get; set; }

		public Usuario() { }

		public Usuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
		{
			dni = Dni;
			nombre = Nombre;
			mail = Mail;
			password = Password;
			esAdmin = EsAdmin;
			bloqueado = Bloqueado;
		}





		/-******* CLASE USUARIO MANAGER *******-/

		using Microsoft.EntityFrameworkCore;


		private DbSet<Usuario> misUsuarios;
		private MyContext contexto;

		public UsuarioManager()
		{
			inicializarAtributos();
		}

		private void inicializarAtributos()
		{
			try
			{
				//creo un contexto
				contexto = new MyContext();

				//cargo los usuarios
				contexto.usuarios.Load();
				misUsuarios = contexto.usuarios;
			}
			catch (Exception)
			{
			}
		}


		public List<List<string>> obtenerUsuarios()
		{
			List<List<string>> salida = new List<List<string>>();
			foreach (Usuario u in contexto.usuarios)
				salida.Add(new List<string> { u.dni.ToString(), u.nombre, u.mail, u.password, u.esAdmin.ToString(), u.bloqueado }
			return salida;
		}

		public bool agregarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
		{
			try
			{
				Usuario nuevo = new Usuario(Dni, Nombre, Mail, Password, EsAdmin, Bloqueado);
				contexto.usuarios.Add(nuevo);
				contexto.SaveChanges();
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool eliminarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
		{
			try
			{
				bool salida = false;
				foreach (Usuario u in contexto.usuarios)
					if (u.dni == Dni)
					{
						contexto.usuarios.Remove(u);
						salida = true;
					}
				if (salida)
					contexto.SaveChanges();
				return salida;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public bool modificarUsuario(int Dni, string Nombre, string Mail, string Password, bool EsAdmin, bool Bloqueado)
		{
			try
			{
				bool salida = false;
				foreach (Usuario u in contexto.usuarios)
					if (u.dni == Dni)
					{
						u.nombre = Nombre;
						u.mail = Mail;
						u.password = Password;
						u.esAdmin = EsAdmin;
						u.bloqueado = Bloqueado;
						salida = true;
					}
				if (salida)
					contexto.SaveChanges();
				return salida;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void cerrar()
		{
			contexto.Dispose();
		}
		*/

	}
}
