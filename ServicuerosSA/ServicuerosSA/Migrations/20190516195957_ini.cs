using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ServicuerosSA.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bombo",
                columns: table => new
                {
                    BomboId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Capacidad = table.Column<int>(nullable: false),
                    FechaIngreso = table.Column<DateTime>(nullable: false),
                    Num_bombo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bombo", x => x.BomboId);
                });

            migrationBuilder.CreateTable(
                name: "Clasificacion",
                columns: table => new
                {
                    ClasificacionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Selecciones = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificacion", x => x.ClasificacionId);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionesWebblue",
                columns: table => new
                {
                    clasiwebId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionesWebblue", x => x.clasiwebId);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionTripa",
                columns: table => new
                {
                    ClasificacionTripaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionTripa", x => x.ClasificacionTripaId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Direccion = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    RUC = table.Column<string>(nullable: false),
                    Teleofno = table.Column<string>(nullable: false),
                    correo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Medida",
                columns: table => new
                {
                    MedidaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Abreviatura = table.Column<string>(nullable: false),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medida", x => x.MedidaId);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Direccion = table.Column<string>(maxLength: 255, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Estado = table.Column<bool>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    Marcaproveedor = table.Column<string>(nullable: true),
                    Nombres = table.Column<string>(maxLength: 255, nullable: false),
                    Ruc = table.Column<string>(maxLength: 13, nullable: false),
                    Telefono = table.Column<string>(maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "Sexo",
                columns: table => new
                {
                    SexoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexo", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "TipoBodega",
                columns: table => new
                {
                    TipoBodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoBodega", x => x.TipoBodegaId);
                });

            migrationBuilder.CreateTable(
                name: "TipoPiel",
                columns: table => new
                {
                    TipoPielId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPiel", x => x.TipoPielId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personal",
                columns: table => new
                {
                    PersonalId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Apellidos = table.Column<string>(nullable: false),
                    Cedula = table.Column<string>(maxLength: 10, nullable: false),
                    Celular = table.Column<string>(maxLength: 17, nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    SexoId = table.Column<int>(nullable: false),
                    Telefono = table.Column<string>(maxLength: 17, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personal", x => x.PersonalId);
                    table.ForeignKey(
                        name: "FK_Personal_Sexo_SexoId",
                        column: x => x.SexoId,
                        principalTable: "Sexo",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodega",
                columns: table => new
                {
                    BodegaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadAlmacenamiento = table.Column<int>(nullable: false),
                    NombreBodega = table.Column<string>(nullable: false),
                    NumeroEstantes = table.Column<string>(nullable: false),
                    TipoBodegaId = table.Column<int>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega", x => x.BodegaId);
                    table.ForeignKey(
                        name: "FK_Bodega_TipoBodega_TipoBodegaId",
                        column: x => x.TipoBodegaId,
                        principalTable: "TipoBodega",
                        principalColumn: "TipoBodegaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Formula",
                columns: table => new
                {
                    FormulaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Fecha_Creacion = table.Column<DateTime>(nullable: false),
                    Nombre = table.Column<string>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false),
                    TipoProceso = table.Column<string>(nullable: false),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Formula", x => x.FormulaId);
                    table.ForeignKey(
                        name: "FK_Formula_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Lote",
                columns: table => new
                {
                    LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Codigolote = table.Column<string>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    Numerodepieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false),
                    estado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lote", x => x.LoteId);
                    table.ForeignKey(
                        name: "FK_Lote_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Lote_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Componente",
                columns: table => new
                {
                    ComponenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Detalle = table.Column<string>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    Porcentaje = table.Column<string>(nullable: false),
                    Quimico = table.Column<bool>(nullable: false),
                    Tiempo = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente", x => x.ComponenteId);
                    table.ForeignKey(
                        name: "FK_Componente_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Componente_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodega1",
                columns: table => new
                {
                    Bodega1Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BodegaId = table.Column<int>(nullable: false),
                    ClasificacionId = table.Column<int>(nullable: false),
                    Fechaingreso = table.Column<DateTime>(nullable: false),
                    LoteId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    NumeroEstanteria = table.Column<string>(nullable: false),
                    NumeroPieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    Peso = table.Column<int>(nullable: false),
                    TipoPielId = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodega1", x => x.Bodega1Id);
                    table.ForeignKey(
                        name: "FK_Bodega1_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Clasificacion_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "Clasificacion",
                        principalColumn: "ClasificacionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodega1_TipoPiel_TipoPielId",
                        column: x => x.TipoPielId,
                        principalTable: "TipoPiel",
                        principalColumn: "TipoPielId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor_Lote",
                columns: table => new
                {
                    Proveedor_LoteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LoteId = table.Column<int>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor_Lote", x => x.Proveedor_LoteId);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Lote_LoteId",
                        column: x => x.LoteId,
                        principalTable: "Lote",
                        principalColumn: "LoteId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Proveedor_Lote_Proveedor_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedor",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pelambre",
                columns: table => new
                {
                    PelambreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    Bodega1Id = table.Column<int>(nullable: false),
                    BomboId = table.Column<int>(nullable: false),
                    Codigo = table.Column<string>(nullable: true),
                    CodigoLote = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    TotalPieles = table.Column<int>(nullable: false),
                    codigopelambre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pelambre", x => x.PelambreId);
                    table.ForeignKey(
                        name: "FK_Pelambre_Bodega1_Bodega1Id",
                        column: x => x.Bodega1Id,
                        principalTable: "Bodega1",
                        principalColumn: "Bodega1Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pelambre_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Descarne",
                columns: table => new
                {
                    DescarneId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    CodigoLote = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PelambreId = table.Column<int>(nullable: false),
                    PersonalId = table.Column<int>(nullable: false),
                    codigodescarne = table.Column<string>(nullable: true),
                    codiunidescarne = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Descarne", x => x.DescarneId);
                    table.ForeignKey(
                        name: "FK_Descarne_Pelambre_PelambreId",
                        column: x => x.PelambreId,
                        principalTable: "Pelambre",
                        principalColumn: "PelambreId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Descarne_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bodegatripa",
                columns: table => new
                {
                    BodegaTripaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BodegaId = table.Column<int>(nullable: false),
                    ClasificacionTripaId = table.Column<int>(nullable: false),
                    DescarneId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    NumeroPieles = table.Column<decimal>(nullable: false),
                    PersonalId = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    codigolote = table.Column<string>(nullable: true),
                    fecha = table.Column<DateTime>(nullable: false),
                    peso = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bodegatripa", x => x.BodegaTripaId);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_ClasificacionTripa_ClasificacionTripaId",
                        column: x => x.ClasificacionTripaId,
                        principalTable: "ClasificacionTripa",
                        principalColumn: "ClasificacionTripaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_Descarne_DescarneId",
                        column: x => x.DescarneId,
                        principalTable: "Descarne",
                        principalColumn: "DescarneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bodegatripa_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curtido",
                columns: table => new
                {
                    CurtidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    BodegaId = table.Column<int>(nullable: false),
                    BodegaTripaId = table.Column<int>(nullable: false),
                    BomboId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    FormulaId = table.Column<int>(nullable: false),
                    MedidaId = table.Column<int>(nullable: false),
                    NPieles = table.Column<decimal>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    Peso = table.Column<int>(nullable: false),
                    codicurtido = table.Column<string>(nullable: true),
                    codigolote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtido", x => x.CurtidoId);
                    table.ForeignKey(
                        name: "FK_Curtido_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Bodegatripa_BodegaTripaId",
                        column: x => x.BodegaTripaId,
                        principalTable: "Bodegatripa",
                        principalColumn: "BodegaTripaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Formula_FormulaId",
                        column: x => x.FormulaId,
                        principalTable: "Formula",
                        principalColumn: "FormulaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Medida_MedidaId",
                        column: x => x.MedidaId,
                        principalTable: "Medida",
                        principalColumn: "MedidaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curtido_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Escurrido",
                columns: table => new
                {
                    EscurridoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    BomboId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    CodigoLote = table.Column<string>(nullable: true),
                    CurtidoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    PersonalId = table.Column<int>(nullable: false),
                    codiuniescurridio = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escurrido", x => x.EscurridoId);
                    table.ForeignKey(
                        name: "FK_Escurrido_Bombo_BomboId",
                        column: x => x.BomboId,
                        principalTable: "Bombo",
                        principalColumn: "BomboId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Escurrido_Curtido_CurtidoId",
                        column: x => x.CurtidoId,
                        principalTable: "Curtido",
                        principalColumn: "CurtidoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Escurrido_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionWB",
                columns: table => new
                {
                    ClasificacionwbId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Activo = table.Column<bool>(nullable: false),
                    BodegaId = table.Column<int>(nullable: false),
                    EscurridoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NumeroPieles = table.Column<int>(nullable: false),
                    Observaciones = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    bombo = table.Column<int>(nullable: false),
                    clasiwebId = table.Column<int>(nullable: false),
                    codigolote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionWB", x => x.ClasificacionwbId);
                    table.ForeignKey(
                        name: "FK_ClasificacionWB_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClasificacionWB_Escurrido_EscurridoId",
                        column: x => x.EscurridoId,
                        principalTable: "Escurrido",
                        principalColumn: "EscurridoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClasificacionWB_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClasificacionWB_ClasificacionesWebblue_clasiwebId",
                        column: x => x.clasiwebId,
                        principalTable: "ClasificacionesWebblue",
                        principalColumn: "clasiwebId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Calibracion",
                columns: table => new
                {
                    CalibracionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CantidadA = table.Column<int>(nullable: false),
                    CantidadB = table.Column<int>(nullable: false),
                    ClasificacionwbId = table.Column<int>(nullable: false),
                    Fechacalibracion = table.Column<DateTime>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    bombo = table.Column<int>(nullable: false),
                    codigolote = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibracion", x => x.CalibracionId);
                    table.ForeignKey(
                        name: "FK_Calibracion_ClasificacionWB_ClasificacionwbId",
                        column: x => x.ClasificacionwbId,
                        principalTable: "ClasificacionWB",
                        principalColumn: "ClasificacionwbId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medido",
                columns: table => new
                {
                    MedidoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Area = table.Column<decimal>(nullable: false),
                    BodegaId = table.Column<int>(nullable: false),
                    CalibracionId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Codigolote = table.Column<string>(nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Pallet = table.Column<string>(nullable: true),
                    PersonalId = table.Column<int>(nullable: false),
                    activo = table.Column<bool>(nullable: false),
                    estanteria = table.Column<int>(nullable: false),
                    tipotri = table.Column<string>(nullable: true),
                    tipoweb = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medido", x => x.MedidoId);
                    table.ForeignKey(
                        name: "FK_Medido_Bodega_BodegaId",
                        column: x => x.BodegaId,
                        principalTable: "Bodega",
                        principalColumn: "BodegaId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medido_Calibracion_CalibracionId",
                        column: x => x.CalibracionId,
                        principalTable: "Calibracion",
                        principalColumn: "CalibracionId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Medido_Personal_PersonalId",
                        column: x => x.PersonalId,
                        principalTable: "Personal",
                        principalColumn: "PersonalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega_TipoBodegaId",
                table: "Bodega",
                column: "TipoBodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_BodegaId",
                table: "Bodega1",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_ClasificacionId",
                table: "Bodega1",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_LoteId",
                table: "Bodega1",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_MedidaId",
                table: "Bodega1",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodega1_TipoPielId",
                table: "Bodega1",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_BodegaId",
                table: "Bodegatripa",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_ClasificacionTripaId",
                table: "Bodegatripa",
                column: "ClasificacionTripaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_DescarneId",
                table: "Bodegatripa",
                column: "DescarneId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_MedidaId",
                table: "Bodegatripa",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Bodegatripa_PersonalId",
                table: "Bodegatripa",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Calibracion_ClasificacionwbId",
                table: "Calibracion",
                column: "ClasificacionwbId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_BodegaId",
                table: "ClasificacionWB",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_EscurridoId",
                table: "ClasificacionWB",
                column: "EscurridoId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_PersonalId",
                table: "ClasificacionWB",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_ClasificacionWB_clasiwebId",
                table: "ClasificacionWB",
                column: "clasiwebId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_FormulaId",
                table: "Componente",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_MedidaId",
                table: "Componente",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BodegaId",
                table: "Curtido",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BodegaTripaId",
                table: "Curtido",
                column: "BodegaTripaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_BomboId",
                table: "Curtido",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_FormulaId",
                table: "Curtido",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_MedidaId",
                table: "Curtido",
                column: "MedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Curtido_PersonalId",
                table: "Curtido",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Descarne_PelambreId",
                table: "Descarne",
                column: "PelambreId");

            migrationBuilder.CreateIndex(
                name: "IX_Descarne_PersonalId",
                table: "Descarne",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_BomboId",
                table: "Escurrido",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_CurtidoId",
                table: "Escurrido",
                column: "CurtidoId");

            migrationBuilder.CreateIndex(
                name: "IX_Escurrido_PersonalId",
                table: "Escurrido",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Formula_TipoPielId",
                table: "Formula",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_PersonalId",
                table: "Lote",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Lote_TipoPielId",
                table: "Lote",
                column: "TipoPielId");

            migrationBuilder.CreateIndex(
                name: "IX_Medido_BodegaId",
                table: "Medido",
                column: "BodegaId");

            migrationBuilder.CreateIndex(
                name: "IX_Medido_CalibracionId",
                table: "Medido",
                column: "CalibracionId");

            migrationBuilder.CreateIndex(
                name: "IX_Medido_PersonalId",
                table: "Medido",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_Bodega1Id",
                table: "Pelambre",
                column: "Bodega1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_BomboId",
                table: "Pelambre",
                column: "BomboId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_FormulaId",
                table: "Pelambre",
                column: "FormulaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pelambre_PersonalId",
                table: "Pelambre",
                column: "PersonalId");

            migrationBuilder.CreateIndex(
                name: "IX_Personal_SexoId",
                table: "Personal",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_LoteId",
                table: "Proveedor_Lote",
                column: "LoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedor_Lote_ProveedorId",
                table: "Proveedor_Lote",
                column: "ProveedorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Componente");

            migrationBuilder.DropTable(
                name: "Medido");

            migrationBuilder.DropTable(
                name: "Proveedor_Lote");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Calibracion");

            migrationBuilder.DropTable(
                name: "Proveedor");

            migrationBuilder.DropTable(
                name: "ClasificacionWB");

            migrationBuilder.DropTable(
                name: "Escurrido");

            migrationBuilder.DropTable(
                name: "ClasificacionesWebblue");

            migrationBuilder.DropTable(
                name: "Curtido");

            migrationBuilder.DropTable(
                name: "Bodegatripa");

            migrationBuilder.DropTable(
                name: "ClasificacionTripa");

            migrationBuilder.DropTable(
                name: "Descarne");

            migrationBuilder.DropTable(
                name: "Pelambre");

            migrationBuilder.DropTable(
                name: "Bodega1");

            migrationBuilder.DropTable(
                name: "Bombo");

            migrationBuilder.DropTable(
                name: "Formula");

            migrationBuilder.DropTable(
                name: "Bodega");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Lote");

            migrationBuilder.DropTable(
                name: "Medida");

            migrationBuilder.DropTable(
                name: "TipoBodega");

            migrationBuilder.DropTable(
                name: "Personal");

            migrationBuilder.DropTable(
                name: "TipoPiel");

            migrationBuilder.DropTable(
                name: "Sexo");
        }
    }
}
