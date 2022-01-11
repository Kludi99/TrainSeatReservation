//Program powstał na Wydziale Informatyki Politechniki Białostockiej
using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainSeatReservation.Data.Migrations
{
    public partial class AddSeedToDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Carriage");

            migrationBuilder.DropColumn(
                name: "FreeSeats",
                table: "Carriage");

            migrationBuilder.AddColumn<int>(
                name: "TypeId",
                table: "Train",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Discount",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Number",
                table: "Carriage",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUserRole<int>",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUserRole<int>", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ea103caf-c8b1-40e3-afa3-502c40dd623e", "faa5bb76-03f1-4e65-99d6-40ba48f7a821", "Admin", "ADMIN" },
                    { "36314aae-5188-4403-92f7-69f6dc28a3ad", "60027b71-1764-4fda-ab2e-25788796d259", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "Dictionaries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Train Type" },
                    { 2, "Carriage Type" },
                    { 3, "Carriage Class" },
                    { 4, "Seat Type" }
                });

            migrationBuilder.InsertData(
                table: "Discount",
                columns: new[] { "Id", "Description", "Name", "Value" },
                values: new object[,]
                {
                    { 19, "Osoba która ukończyła 60 lat", "Bilet dla Seniora", 30 },
                    { 18, "Honorowi dawcy krwi, którzy w przypadku ogłoszenia stanu zagrożenia epidemicznego albo stanu\r\n                                    epidemii oddali co najmniej 3 donacje krwi lub jej\r\n                                    składników, w tym osocze po chorobie COVID- 19 ", "Honorowy Dawca Krwi", 33 },
                    { 16, "Rodzice lub małżonkowie rodziców posiadający Kartę Dużej Rodziny w rozumieniu\r\n                                    ustawy o Karcie Dużej Rodziny", "Rodzic/Małżonek rodzica  - Karta Dużej Rodziny", 37 },
                    { 15, "Działacze opozycji antykomunistycznej oraz osoby\r\n                                    represjonowane z powodów politycznych ", "Działacze opozycji antykomunistycznej/osob represjonowane politycznie", 51 },
                    { 14, "Kombatanci będący inwalidami wojennymi lub\r\n                                    wojskowymi zaliczonymi do II lub III grupy inwalidów lub uznani za całkowicie lub częściowo\r\n                                    niezdolnych do pracy", "Kombatanci", 51 },
                    { 13, "Osoby niewidome uznane za osoby niezdolne do samodzielnej egzystencji*)\r\n                                    *) za osobę niezdolną do samodzielnej\r\n                                    egzystencji należy również uważać osobę niepełnosprawną w stopniu znacznym\r\n                                    i inwalidę I grupy (jeżeli orzeczenie o\r\n                                    zaliczeniu do tej grupy nie utraciło mocy)", "Niewidominiezdolni do samodzielnej egzystencji", 51 },
                    { 12, "1) studenci do ukończenia 26 roku życia,\r\n                                    2) słuchacze kolegiów pracowników służb\r\n                                    społecznych, do ukończenia 26 roku\r\n                                    życia,\r\n                                    3) doktoranci do ukończenia 35 roku życia,\r\n                                    4) Studenci – studiujący za granicą, do ukończenia 26 roku życia ", "Studenci do 26 lat/Doktoranci do 35 lat", 51 },
                    { 11, "Cywilna niewidoma ofiara działań wojennych uznana za osobę niezdolną do samodzielnej egzystencji", "Cywilne niewidome ofiary wojny niezdolne do samodzielnej egzystencji", 78 },
                    { 10, "Dzieci i młodzież dotknięte inwalidztwem\r\n                                    lub niepełnosprawne do ukończenia 24\r\n                                    roku życia oraz studenci dotknięci inwalidztwem lub niepełnosprawni do ukończenia 26 roku życia – wyłącznie przy przejazdach z miejsca zamieszkania lub z\r\n                                    miejsca pobytu (za aktualne miejsce pobytu uznaje się każde miejsce deklarowane\r\n                                    przez podróżnego) do przedszkola, szkoły,\r\n                                    szkoły wyższej, placówki opiekuńczo–\r\n                                    wychowawczej, placówki oświatowo–\r\n                                    wychowawczej, specjalnego ośrodka\r\n                                    szkolno–wychowawczego, specjalnego\r\n                                    ośrodka wychowawczego, ośrodka umożliwiającego dzieciom i młodzieży spełnianie obowiązku szkolnego i obowiązku\r\n                                    nauki, ośrodka rehabilitacyjnowychowawczego, domu pomocy społecznej, ośrodka wsparcia, zakładu opieki\r\n                                    zdrowotnej, poradni psychologiczno–\r\n                                    pedagogicznej, w tym poradni specjalistycznej, a także na turnus rehabilitacyjny\r\n                                    – i z powrotem", "Dzieci/Młodzież/Studenci niepełnosprawni", 78 },
                    { 17, "Dzieci i młodzież w okresie od rozpoczęcia\r\n                                    odbywania obowiązkowego rocznego\r\n                                    przygotowania przedszkolnego do ukończenia szkoły podstawowej lub ponadpodstawowej – publicznej lub niepublicznej o\r\n                                    uprawnieniach szkoły publicznej, nie dłużej\r\n                                    niż do ukończenia 24 roku życia", "Dzieci/Młodzież", 37 },
                    { 8, "Żołnierze odbywający niezawodową służbę\r\n                                    wojskową*), z wyjątkiem służby okresowej\r\n                                    i nadterminowej oraz osoby spełniające\r\n                                    obowiązek tej służby w formach równorzędnych\r\n                                    *) tj. żołnierze odbywający:\r\n                                    a) zasadniczą służbę wojskową, w tym służbę kandydacką w Oddziałach Prewencji\r\n                                    Policji, Straży Granicznej lub w Służbie\r\n                                    Ochrony Państwa oraz pełniący terytorialną służbę wojskową albo służbę przygotowawczą;\r\n                                    b) służbę zastępczą,\r\n                                    c) służbę w charakterze kandydatów na żołnierzy zawodowych, tj. pobierający naukę\r\n                                    w:\r\n                                    - uczelni wojskowej (podchorążowie),\r\n                                    - szkole podoficerskiej (kadeci),\r\n                                    - ośrodku szkolenia (elewi),\r\n                                    - orkiestrze,\r\n                                    d) szkolenie wojskowe (dotyczy osób będących cywilnymi studentami uczelni wojskowej lub studentami innej uczelni niż\r\n                                    uczelnia wojskowa powołanych do służby\r\n                                    kandydackiej. Kandydat taki odbywa szkolenie w okresie wakacyjnym)\r\n                                    e) zajęcia wojskowe (dot. studentów szkół\r\n                                    morskich i akademii morskich) lub przeszkolenie wojskowe,\r\n                                    f) ćwiczenia wojskowe.", "Żołnierze", 78 },
                    { 7, "Przewodnik lub opiekun towarzyszący w podróży\r\n                                    osobie wymienionej w poz. 1 lub 2:\r\n                                    1) Inwalidzi wojenni i wojskowi zaliczeni do I grupy\r\n                                    inwalidów lub uznani za całkowicie niezdolnych do\r\n                                    pracy i niezdolnych do samodzielnej egzystencji\r\n                                    (choćby bez związku z działaniami wojennymi lub\r\n                                    służbą wojskową)\r\n                                    2) Kombatanci będący inwalidami wojennymi lub\r\n                                    wojskowymi zaliczonymi do I grupy inwalidów\r\n                                    lub uznani za całkowicie niezdolnych do pracy\r\n                                    i niezdolnych do samodzielnej egzystencji, także\r\n                                    w przypadku zaliczenia do I grupy inwalidów\r\n                                    (uznania niezdolności do samodzielnej egzystencji)\r\n                                    z ogólnego stanu zdrowia ", "Przewodnik kombatanta/inwalidy gr. I ", 95 },
                    { 6, "Opiekun lub przewodnik towarzyszący\r\n                                    w podróży:\r\n                                    1) osobie niezdolnej do samodzielnej\r\n                                    egzystencji ,\r\n                                    albo\r\n                                    2) osobie niewidomej", "Opiekun/Przewodnik", 95 },
                    { 5, "Żołnierze Żandarmerii Wojskowej oraz\r\n                                    wojskowych organów porządkowych,\r\n                                    wykonujący czynności urzędowe patrolowania i inne czynności służbowe\r\n                                    w środkach transportu zbiorowego", "Żołnierze Żandarmerii Wojskowej", 100 },
                    { 4, "Umundurowani funkcjonariusze Policji\r\n                                    w czasie konwojowania osób zatrzymanych\r\n                                    lub chronionego mienia, przewożenia poczty\r\n                                    specjalnej, służby patrolowej oraz udzielania\r\n                                    pomocy lub asystowania przy czynnościach\r\n                                    organów egzekucyjnych", "Umundurowani funkcjonariusze Policji", 100 },
                    { 3, "Funkcjonariusze Służby Celno-Skarbowej w\r\n                                    czasie wykonywania czynności służbowych\r\n                                    kontroli określonej w dziale V ustawy z dnia\r\n                                    16 listopada 2016 r. o Krajowej Administracji Skarbowej (jednolity tekst Dz.U. 2020\r\n                                    poz. 505)", "Funkcjonariusze Służby Celno-Skarbowej", 100 },
                    { 9, " 1) Inwalidzi wojenni i wojskowi zaliczeni do I grupy\r\n                                    inwalidów lub uznani za całkowicie niezdolnych do\r\n                                    pracy i niezdolnych do samodzielnej egzystencji\r\n                                    (choćby bez związku z działaniami wojennymi lub\r\n                                    służbą wojskową)\r\n                                    2) Kombatanci będący inwalidami wojennymi lub\r\n                                    wojskowymi zaliczonymi do I grupy inwalidów\r\n                                    lub uznani za całkowicie niezdolnych do pracy\r\n                                    i niezdolnych do samodzielnej egzystencji, także\r\n                                    w przypadku zaliczenia do I grupy inwalidów\r\n                                    (uznania niezdolności do samodzielnej egzystencji)\r\n                                    z ogólnego stanu zdrowia ", "Kombatant/inwalida gr. I", 78 },
                    { 2, "Funkcjonariusze Straży Granicznej:\r\n                                    1) umundurowani – w czasie wykonywania\r\n                                    czynności służbowych związanych\r\n                                    z ochroną granicy państwowej, a także\r\n                                    w czasie konwojowania osób zatrzymanych, służby patrolowej oraz wykonywania czynności związanych z kontrolą ruchu granicznego,\r\n                                    2) w czasie wykonywania czynności służbowych związanych z zapobieganiem i\r\n                                    przeciwdziałaniem nielegalnej migracji,\r\n                                    realizowanych na szlakach komunikacyjnych o szczególnym znaczeniu międzynarodowym", "Funkcjonariusze Straży Granicznej", 100 },
                    { 1, "Dzieci w wieku do 4 lat", "Dla dziecka do lat 4", 100 }
                });

            migrationBuilder.InsertData(
                table: "Route",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Białystok-Kraków Główny" },
                    { 1, "Białystok-Zgorzelec" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 23, "Opole", "Opole Główne" },
                    { 24, "Brzeg", "Brzeg" },
                    { 25, "Oława", "Oława" },
                    { 22, "Lubliniec", "Lubliniec" },
                    { 26, "Wrocław", "Wrocław Głowny" },
                    { 27, "Wrocław", "Wrocław Leśnica" },
                    { 28, "Środa Śląska", "Środa Śląska" },
                    { 29, "Legnica", "Legnica" },
                    { 34, "Zgorzelec", "Zgorzelec Miasto" },
                    { 31, "Bolesławiec", "Bolesławiec" },
                    { 32, "Węgliniec", "Węgliniec" },
                    { 33, "Pieńsk", "Pieńsk" },
                    { 35, "Zgorzelec", "Zgorzelec" },
                    { 36, "Opoczno", "Opoczno Południe" },
                    { 37, "Włoszczowa", "Włoszczowa Północ" }
                });

            migrationBuilder.InsertData(
                table: "Station",
                columns: new[] { "Id", "City", "Name" },
                values: new object[,]
                {
                    { 21, "Częstochowa", "Częstochowa Stardom" },
                    { 30, "Chojnów", "Chojnów" },
                    { 20, "Częstochowa", "Częstochowa" },
                    { 6, "Jabłoń Kościelna", "Jabłoń Kościelna" },
                    { 18, "Piotrków Trybunalski", "Piotrków Trybunalski" },
                    { 1, "Białystok", "Białystok" },
                    { 2, "Łapy", "Łapy" },
                    { 3, "Łapy", "Łapy Osse" },
                    { 4, "Zdrody Nowe", "Zdrody Nowe" },
                    { 5, "Racibory", "Racibory" },
                    { 38, "Miechów", "Miechów" },
                    { 7, "Szymbory", "Szymbory" },
                    { 8, "Szepietowo", "Szepietowo" },
                    { 9, "Czyżew", "Czyżew" },
                    { 10, "Małkinia", "Małkinia" },
                    { 11, "Łochów", "Łochów" },
                    { 12, "Tłuszcz", "Tłuszcz" },
                    { 13, "Wołomin", "Wołomin" },
                    { 14, "Warszawa", "Warszawa Wschodnia" },
                    { 15, "Warszawa", "Warszawa Centralna" },
                    { 16, "Warszawa", "Warszawa Zachodnia" },
                    { 17, "Koluszki", "Koluszki" },
                    { 19, "Radomsko", "Radomsko" },
                    { 39, "Kraków", "Kraków Główny" }
                });

            migrationBuilder.InsertData(
                table: "DictionaryItems",
                columns: new[] { "Id", "DictionaryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "IC" },
                    { 12, 4, "Przy stoliku" },
                    { 10, 4, "Korytarz" },
                    { 9, 4, "Okno" },
                    { 8, 3, "2 klasa" },
                    { 7, 3, "1 klasa" },
                    { 11, 4, "Środek" },
                    { 5, 2, "Przedziałowy" },
                    { 4, 1, "POLREGIO" },
                    { 3, 1, "EIP" },
                    { 2, 1, "EIC" },
                    { 6, 2, "Bezprzedziałowy" }
                });

            migrationBuilder.InsertData(
                table: "RouteStation",
                columns: new[] { "Id", "Distance", "EndStationId", "Order", "Price", "RouteId", "StartStationId" },
                values: new object[,]
                {
                    { 24, 20, 25, 24, 5.0, 1, 24 },
                    { 16, 45, 17, 16, 5.0, 1, 16 },
                    { 17, 32, 18, 17, 5.0, 1, 17 },
                    { 18, 23, 19, 18, 5.0, 1, 18 },
                    { 19, 21, 20, 19, 5.0, 1, 19 },
                    { 20, 21, 21, 20, 5.0, 1, 20 },
                    { 21, 30, 22, 21, 5.0, 1, 21 },
                    { 22, 20, 23, 22, 5.0, 1, 22 },
                    { 23, 36, 24, 23, 5.0, 1, 23 },
                    { 25, 17, 26, 25, 5.0, 1, 25 },
                    { 31, 30, 32, 31, 5.0, 1, 31 },
                    { 27, 32, 28, 27, 5.0, 1, 27 },
                    { 28, 23, 29, 28, 5.0, 1, 28 },
                    { 29, 21, 30, 29, 5.0, 1, 29 },
                    { 30, 21, 31, 30, 5.0, 1, 30 },
                    { 44, 20, 16, 10, 5.0, 2, 15 },
                    { 32, 20, 33, 32, 5.0, 1, 32 },
                    { 33, 36, 34, 33, 5.0, 1, 33 },
                    { 34, 20, 35, 34, 5.0, 1, 34 },
                    { 45, 17, 36, 11, 5.0, 2, 16 },
                    { 46, 45, 37, 12, 5.0, 2, 36 },
                    { 26, 45, 27, 26, 5.0, 1, 26 },
                    { 15, 17, 16, 15, 5.0, 1, 15 },
                    { 12, 20, 13, 12, 5.0, 1, 12 },
                    { 14, 20, 15, 14, 5.0, 1, 14 },
                    { 1, 30, 2, 1, 5.0, 1, 1 },
                    { 35, 17, 2, 1, 5.0, 2, 1 },
                    { 2, 20, 3, 2, 5.0, 1, 2 },
                    { 3, 36, 4, 3, 5.0, 1, 3 },
                    { 4, 20, 5, 4, 5.0, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "RouteStation",
                columns: new[] { "Id", "Distance", "EndStationId", "Order", "Price", "RouteId", "StartStationId" },
                values: new object[,]
                {
                    { 5, 17, 6, 5, 5.0, 1, 5 },
                    { 6, 45, 7, 6, 5.0, 1, 6 },
                    { 7, 32, 8, 7, 5.0, 1, 7 },
                    { 36, 45, 8, 2, 5.0, 2, 2 },
                    { 8, 23, 9, 8, 5.0, 1, 8 },
                    { 37, 32, 9, 3, 5.0, 2, 8 },
                    { 9, 21, 10, 9, 5.0, 1, 9 },
                    { 38, 23, 10, 4, 5.0, 2, 9 },
                    { 10, 21, 11, 10, 5.0, 1, 10 },
                    { 39, 21, 11, 5, 5.0, 2, 10 },
                    { 11, 30, 12, 11, 5.0, 1, 11 },
                    { 40, 21, 12, 6, 5.0, 2, 11 },
                    { 47, 32, 38, 13, 5.0, 2, 37 },
                    { 41, 30, 13, 7, 5.0, 2, 12 },
                    { 13, 36, 14, 13, 5.0, 1, 13 },
                    { 42, 20, 14, 8, 5.0, 2, 13 },
                    { 43, 36, 15, 9, 5.0, 2, 14 },
                    { 48, 23, 39, 14, 5.0, 2, 38 }
                });

            migrationBuilder.InsertData(
                table: "Carriage",
                columns: new[] { "Id", "CarriageClassId", "IsActive", "Number", "TypeId" },
                values: new object[,]
                {
                    { 17, 7, true, 7, 6 },
                    { 13, 8, true, 3, 6 },
                    { 12, 8, true, 2, 6 },
                    { 11, 8, true, 1, 6 },
                    { 10, 8, true, 10, 5 },
                    { 9, 8, true, 9, 5 },
                    { 8, 8, true, 8, 5 },
                    { 7, 8, true, 7, 5 },
                    { 6, 8, true, 6, 5 },
                    { 15, 8, true, 5, 6 },
                    { 16, 7, true, 6, 6 },
                    { 5, 7, true, 5, 5 },
                    { 4, 7, true, 4, 5 },
                    { 3, 7, true, 3, 5 },
                    { 2, 7, true, 2, 5 },
                    { 1, 7, true, 1, 6 },
                    { 14, 8, true, 4, 6 }
                });

            migrationBuilder.InsertData(
                table: "Train",
                columns: new[] { "Id", "IsActive", "Name", "Number", "TypeId" },
                values: new object[,]
                {
                    { 3, true, "Karkonosze", "IC 23441", 1 },
                    { 2, true, "Hańcza", "IC 10511", 1 },
                    { 1, true, "Nałkowska", "IC 10221", 1 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 191, 7, true, 10, 9 },
                    { 251, 9, true, 10, 9 },
                    { 252, 9, true, 11, 10 },
                    { 253, 9, true, 12, 11 },
                    { 254, 9, true, 13, 9 },
                    { 255, 9, true, 14, 10 },
                    { 256, 9, true, 15, 11 },
                    { 452, 14, true, 4, 10 },
                    { 257, 9, true, 20, 9 },
                    { 259, 9, true, 22, 11 },
                    { 260, 9, true, 23, 9 },
                    { 261, 9, true, 24, 10 },
                    { 262, 9, true, 25, 11 },
                    { 263, 9, true, 30, 9 },
                    { 264, 9, true, 31, 10 },
                    { 258, 9, true, 21, 10 },
                    { 250, 8, true, 55, 11 },
                    { 249, 8, true, 54, 10 },
                    { 248, 8, true, 53, 9 },
                    { 233, 8, true, 30, 9 },
                    { 234, 8, true, 31, 10 },
                    { 235, 8, true, 32, 11 },
                    { 236, 8, true, 33, 9 },
                    { 237, 8, true, 34, 10 },
                    { 238, 8, true, 35, 11 },
                    { 239, 8, true, 40, 9 },
                    { 240, 8, true, 41, 10 },
                    { 241, 8, true, 42, 11 },
                    { 242, 8, true, 43, 9 },
                    { 243, 8, true, 44, 10 },
                    { 244, 8, true, 45, 11 },
                    { 245, 8, true, 50, 9 },
                    { 246, 8, true, 51, 10 },
                    { 247, 8, true, 52, 11 },
                    { 265, 9, true, 32, 11 },
                    { 232, 8, true, 25, 11 },
                    { 266, 9, true, 33, 9 },
                    { 268, 9, true, 35, 11 },
                    { 287, 10, true, 20, 9 },
                    { 288, 10, true, 21, 10 },
                    { 289, 10, true, 22, 11 },
                    { 290, 10, true, 23, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 291, 10, true, 24, 10 },
                    { 292, 10, true, 25, 11 },
                    { 286, 10, true, 15, 11 },
                    { 293, 10, true, 30, 9 },
                    { 295, 10, true, 32, 11 },
                    { 296, 10, true, 33, 9 },
                    { 297, 10, true, 34, 10 },
                    { 298, 10, true, 35, 11 },
                    { 299, 10, true, 40, 9 },
                    { 300, 10, true, 41, 10 },
                    { 294, 10, true, 31, 10 },
                    { 285, 10, true, 14, 10 },
                    { 284, 10, true, 13, 9 },
                    { 283, 10, true, 12, 11 },
                    { 269, 9, true, 40, 9 },
                    { 270, 9, true, 41, 10 },
                    { 271, 9, true, 42, 11 },
                    { 272, 9, true, 43, 9 },
                    { 273, 9, true, 44, 10 },
                    { 274, 9, true, 45, 11 },
                    { 275, 9, true, 50, 9 },
                    { 276, 9, true, 51, 10 },
                    { 277, 9, true, 52, 11 },
                    { 278, 9, true, 53, 9 },
                    { 279, 9, true, 54, 10 },
                    { 280, 9, true, 55, 11 },
                    { 451, 14, true, 2, 10 },
                    { 281, 10, true, 10, 9 },
                    { 282, 10, true, 11, 10 },
                    { 267, 9, true, 34, 10 },
                    { 301, 10, true, 42, 11 },
                    { 231, 8, true, 24, 10 },
                    { 229, 8, true, 22, 11 },
                    { 180, 6, true, 41, 10 },
                    { 181, 6, true, 42, 11 },
                    { 182, 6, true, 43, 9 },
                    { 183, 6, true, 44, 10 },
                    { 184, 6, true, 45, 11 },
                    { 185, 6, true, 50, 9 },
                    { 179, 6, true, 40, 9 },
                    { 186, 6, true, 51, 10 },
                    { 188, 6, true, 53, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 189, 6, true, 54, 10 },
                    { 190, 6, true, 55, 11 },
                    { 454, 14, true, 8, 10 },
                    { 510, 15, true, 40, 10 },
                    { 192, 7, true, 11, 10 },
                    { 187, 6, true, 52, 11 },
                    { 178, 6, true, 35, 11 },
                    { 177, 6, true, 34, 10 },
                    { 176, 6, true, 33, 9 },
                    { 161, 6, true, 10, 9 },
                    { 162, 6, true, 11, 10 },
                    { 163, 6, true, 12, 11 },
                    { 164, 6, true, 13, 9 },
                    { 165, 6, true, 14, 10 },
                    { 166, 6, true, 15, 11 },
                    { 167, 6, true, 20, 9 },
                    { 168, 6, true, 21, 10 },
                    { 169, 6, true, 22, 11 },
                    { 170, 6, true, 23, 9 },
                    { 171, 6, true, 24, 10 },
                    { 172, 6, true, 25, 11 },
                    { 173, 6, true, 30, 9 },
                    { 174, 6, true, 31, 10 },
                    { 175, 6, true, 32, 11 },
                    { 193, 7, true, 12, 11 },
                    { 230, 8, true, 23, 9 },
                    { 194, 7, true, 13, 9 },
                    { 196, 7, true, 15, 11 },
                    { 216, 7, true, 51, 10 },
                    { 217, 7, true, 52, 11 },
                    { 218, 7, true, 53, 9 },
                    { 219, 7, true, 54, 10 },
                    { 220, 7, true, 55, 11 },
                    { 453, 14, true, 6, 10 },
                    { 215, 7, true, 50, 9 },
                    { 221, 8, true, 10, 9 },
                    { 223, 8, true, 12, 11 },
                    { 224, 8, true, 13, 9 },
                    { 225, 8, true, 14, 10 },
                    { 226, 8, true, 15, 11 },
                    { 227, 8, true, 20, 9 },
                    { 228, 8, true, 21, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 222, 8, true, 11, 10 },
                    { 214, 7, true, 45, 11 },
                    { 213, 7, true, 44, 10 },
                    { 212, 7, true, 43, 9 },
                    { 197, 7, true, 20, 9 },
                    { 198, 7, true, 21, 10 },
                    { 199, 7, true, 22, 11 },
                    { 200, 7, true, 23, 9 },
                    { 201, 7, true, 24, 10 },
                    { 202, 7, true, 25, 11 },
                    { 203, 7, true, 30, 9 },
                    { 204, 7, true, 31, 10 },
                    { 205, 7, true, 32, 11 },
                    { 206, 7, true, 33, 9 },
                    { 207, 7, true, 34, 10 },
                    { 208, 7, true, 35, 11 },
                    { 209, 7, true, 40, 9 },
                    { 210, 7, true, 41, 10 },
                    { 211, 7, true, 42, 11 },
                    { 195, 7, true, 14, 10 },
                    { 455, 14, true, 10, 10 },
                    { 302, 10, true, 43, 9 },
                    { 304, 10, true, 45, 11 },
                    { 395, 13, true, 9, 9 },
                    { 396, 13, true, 11, 9 },
                    { 397, 13, true, 13, 9 },
                    { 398, 13, true, 15, 9 },
                    { 399, 13, true, 17, 9 },
                    { 400, 13, true, 19, 9 },
                    { 394, 13, true, 7, 9 },
                    { 401, 13, true, 21, 9 },
                    { 403, 13, true, 25, 9 },
                    { 404, 13, true, 27, 9 },
                    { 405, 13, true, 29, 9 },
                    { 406, 13, true, 31, 9 },
                    { 407, 13, true, 33, 9 },
                    { 408, 13, true, 35, 9 },
                    { 402, 13, true, 23, 9 },
                    { 393, 13, true, 5, 9 },
                    { 392, 13, true, 3, 9 },
                    { 391, 13, true, 1, 9 },
                    { 377, 12, true, 14, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 378, 12, true, 16, 10 },
                    { 379, 12, true, 18, 10 },
                    { 380, 12, true, 20, 10 },
                    { 381, 12, true, 22, 10 },
                    { 382, 12, true, 24, 10 },
                    { 383, 12, true, 26, 10 },
                    { 384, 12, true, 28, 10 },
                    { 385, 12, true, 30, 10 },
                    { 386, 12, true, 32, 10 },
                    { 387, 12, true, 34, 10 },
                    { 388, 12, true, 36, 10 },
                    { 389, 12, true, 38, 10 },
                    { 390, 12, true, 40, 10 },
                    { 448, 14, true, 35, 9 },
                    { 409, 13, true, 37, 9 },
                    { 376, 12, true, 12, 10 },
                    { 410, 13, true, 39, 9 },
                    { 412, 13, true, 4, 10 },
                    { 431, 14, true, 1, 9 },
                    { 432, 14, true, 3, 9 },
                    { 433, 14, true, 5, 9 },
                    { 434, 14, true, 7, 9 },
                    { 435, 14, true, 9, 9 },
                    { 436, 14, true, 11, 9 },
                    { 447, 14, true, 33, 9 },
                    { 437, 14, true, 13, 9 },
                    { 439, 14, true, 17, 9 },
                    { 440, 14, true, 19, 9 },
                    { 441, 14, true, 21, 9 },
                    { 442, 14, true, 23, 9 },
                    { 443, 14, true, 25, 9 },
                    { 444, 14, true, 27, 9 },
                    { 438, 14, true, 15, 9 },
                    { 430, 13, true, 40, 10 },
                    { 429, 13, true, 38, 10 },
                    { 428, 13, true, 36, 10 },
                    { 413, 13, true, 6, 10 },
                    { 414, 13, true, 8, 10 },
                    { 415, 13, true, 10, 10 },
                    { 416, 13, true, 12, 10 },
                    { 417, 13, true, 14, 10 },
                    { 418, 13, true, 16, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 419, 13, true, 18, 10 },
                    { 420, 13, true, 20, 10 },
                    { 421, 13, true, 22, 10 },
                    { 422, 13, true, 24, 10 },
                    { 423, 13, true, 26, 10 },
                    { 424, 13, true, 28, 10 },
                    { 425, 13, true, 30, 10 },
                    { 426, 13, true, 32, 10 },
                    { 427, 13, true, 34, 10 },
                    { 411, 13, true, 2, 10 },
                    { 303, 10, true, 44, 10 },
                    { 375, 12, true, 10, 10 },
                    { 373, 12, true, 6, 10 },
                    { 323, 11, true, 25, 9 },
                    { 324, 11, true, 27, 9 },
                    { 325, 11, true, 29, 9 },
                    { 326, 11, true, 31, 9 },
                    { 327, 11, true, 33, 9 },
                    { 328, 11, true, 35, 9 },
                    { 322, 11, true, 23, 9 },
                    { 329, 11, true, 37, 9 },
                    { 331, 11, true, 2, 10 },
                    { 332, 11, true, 4, 10 },
                    { 333, 11, true, 6, 10 },
                    { 334, 11, true, 8, 10 },
                    { 335, 11, true, 10, 10 },
                    { 336, 11, true, 12, 10 },
                    { 330, 11, true, 39, 9 },
                    { 321, 11, true, 21, 9 },
                    { 320, 11, true, 19, 9 },
                    { 319, 11, true, 17, 9 },
                    { 305, 10, true, 50, 9 },
                    { 306, 10, true, 51, 10 },
                    { 307, 10, true, 52, 11 },
                    { 308, 10, true, 53, 9 },
                    { 309, 10, true, 54, 10 },
                    { 310, 10, true, 55, 11 },
                    { 450, 14, true, 39, 9 },
                    { 311, 11, true, 1, 9 },
                    { 312, 11, true, 3, 9 },
                    { 313, 11, true, 5, 9 },
                    { 314, 11, true, 7, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 315, 11, true, 9, 9 },
                    { 316, 11, true, 11, 9 },
                    { 317, 11, true, 13, 9 },
                    { 318, 11, true, 15, 9 },
                    { 337, 11, true, 14, 10 },
                    { 374, 12, true, 8, 10 },
                    { 338, 11, true, 16, 10 },
                    { 340, 11, true, 20, 10 },
                    { 359, 12, true, 17, 9 },
                    { 360, 12, true, 19, 9 },
                    { 361, 12, true, 21, 9 },
                    { 362, 12, true, 23, 9 },
                    { 363, 12, true, 25, 9 },
                    { 364, 12, true, 27, 9 },
                    { 358, 12, true, 15, 9 },
                    { 365, 12, true, 29, 9 },
                    { 367, 12, true, 33, 9 },
                    { 368, 12, true, 35, 9 },
                    { 369, 12, true, 37, 9 },
                    { 370, 12, true, 39, 9 },
                    { 371, 12, true, 2, 10 },
                    { 372, 12, true, 4, 10 },
                    { 366, 12, true, 31, 9 },
                    { 357, 12, true, 13, 9 },
                    { 356, 12, true, 11, 9 },
                    { 355, 12, true, 9, 9 },
                    { 341, 11, true, 22, 10 },
                    { 342, 11, true, 24, 10 },
                    { 343, 11, true, 26, 10 },
                    { 344, 11, true, 28, 10 },
                    { 345, 11, true, 30, 10 },
                    { 346, 11, true, 32, 10 },
                    { 347, 11, true, 34, 10 },
                    { 348, 11, true, 36, 10 },
                    { 349, 11, true, 38, 10 },
                    { 350, 11, true, 40, 10 },
                    { 449, 14, true, 37, 9 },
                    { 351, 12, true, 1, 9 },
                    { 352, 12, true, 3, 9 },
                    { 353, 12, true, 5, 9 },
                    { 354, 12, true, 7, 9 },
                    { 339, 11, true, 18, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 445, 14, true, 29, 9 },
                    { 590, 17, true, 40, 10 },
                    { 588, 17, true, 36, 10 },
                    { 44, 2, true, 13, 9 },
                    { 45, 2, true, 14, 10 },
                    { 46, 2, true, 15, 11 },
                    { 47, 2, true, 20, 9 },
                    { 48, 2, true, 21, 10 },
                    { 49, 2, true, 22, 11 },
                    { 43, 2, true, 12, 11 },
                    { 50, 2, true, 23, 9 },
                    { 52, 2, true, 25, 11 },
                    { 53, 2, true, 30, 9 },
                    { 54, 2, true, 31, 10 },
                    { 55, 2, true, 32, 11 },
                    { 56, 2, true, 33, 9 },
                    { 57, 2, true, 34, 10 },
                    { 51, 2, true, 24, 10 },
                    { 58, 2, true, 35, 11 },
                    { 42, 2, true, 11, 10 },
                    { 461, 14, true, 22, 10 },
                    { 27, 1, true, 14, 10 },
                    { 28, 1, true, 16, 10 },
                    { 29, 1, true, 18, 10 },
                    { 30, 1, true, 20, 10 },
                    { 31, 1, true, 22, 10 },
                    { 32, 1, true, 24, 10 },
                    { 41, 2, true, 10, 9 },
                    { 33, 1, true, 26, 10 },
                    { 35, 1, true, 30, 10 },
                    { 36, 1, true, 32, 10 },
                    { 37, 1, true, 34, 10 },
                    { 38, 1, true, 36, 10 },
                    { 39, 1, true, 38, 10 },
                    { 40, 1, true, 40, 10 },
                    { 34, 1, true, 28, 10 },
                    { 59, 2, true, 40, 9 },
                    { 60, 2, true, 41, 10 },
                    { 61, 2, true, 42, 11 },
                    { 80, 3, true, 23, 9 },
                    { 81, 3, true, 24, 10 },
                    { 82, 3, true, 25, 11 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 83, 3, true, 30, 9 },
                    { 84, 3, true, 31, 10 },
                    { 85, 3, true, 32, 11 },
                    { 79, 3, true, 22, 11 },
                    { 86, 3, true, 33, 9 },
                    { 88, 3, true, 35, 11 },
                    { 89, 3, true, 40, 9 },
                    { 90, 3, true, 41, 10 },
                    { 91, 3, true, 42, 11 },
                    { 92, 3, true, 43, 9 },
                    { 93, 3, true, 44, 10 },
                    { 87, 3, true, 34, 10 },
                    { 78, 3, true, 21, 10 },
                    { 77, 3, true, 20, 9 },
                    { 76, 3, true, 15, 11 },
                    { 62, 2, true, 43, 9 },
                    { 63, 2, true, 44, 10 },
                    { 64, 2, true, 45, 11 },
                    { 65, 2, true, 50, 9 },
                    { 66, 2, true, 51, 10 },
                    { 67, 2, true, 52, 11 },
                    { 68, 2, true, 53, 9 },
                    { 69, 2, true, 54, 10 },
                    { 70, 2, true, 55, 11 },
                    { 460, 14, true, 20, 10 },
                    { 71, 3, true, 10, 9 },
                    { 72, 3, true, 11, 10 },
                    { 73, 3, true, 12, 11 },
                    { 74, 3, true, 13, 9 },
                    { 75, 3, true, 14, 10 },
                    { 26, 1, true, 12, 10 },
                    { 25, 1, true, 10, 10 },
                    { 24, 1, true, 8, 10 },
                    { 23, 1, true, 6, 10 },
                    { 490, 15, true, 39, 9 },
                    { 489, 15, true, 37, 9 },
                    { 488, 15, true, 35, 9 },
                    { 487, 15, true, 33, 9 },
                    { 486, 15, true, 31, 9 },
                    { 485, 15, true, 29, 9 },
                    { 491, 15, true, 2, 10 },
                    { 484, 15, true, 27, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 482, 15, true, 23, 9 },
                    { 481, 15, true, 21, 9 },
                    { 480, 15, true, 19, 9 },
                    { 479, 15, true, 17, 9 },
                    { 478, 15, true, 15, 9 },
                    { 477, 15, true, 13, 9 },
                    { 483, 15, true, 25, 9 },
                    { 492, 15, true, 4, 10 },
                    { 493, 15, true, 6, 10 },
                    { 494, 15, true, 8, 10 },
                    { 509, 15, true, 38, 10 },
                    { 508, 15, true, 36, 10 },
                    { 507, 15, true, 34, 10 },
                    { 506, 15, true, 32, 10 },
                    { 505, 15, true, 30, 10 },
                    { 504, 15, true, 28, 10 },
                    { 503, 15, true, 26, 10 },
                    { 502, 15, true, 24, 10 },
                    { 501, 15, true, 22, 10 },
                    { 500, 15, true, 20, 10 },
                    { 499, 15, true, 18, 10 },
                    { 498, 15, true, 16, 10 },
                    { 497, 15, true, 14, 10 },
                    { 496, 15, true, 12, 10 },
                    { 495, 15, true, 10, 10 },
                    { 476, 15, true, 11, 9 },
                    { 94, 3, true, 45, 11 },
                    { 475, 15, true, 9, 9 },
                    { 473, 15, true, 5, 9 },
                    { 9, 1, true, 17, 9 },
                    { 10, 1, true, 19, 9 },
                    { 11, 1, true, 21, 9 },
                    { 12, 1, true, 23, 9 },
                    { 13, 1, true, 25, 9 },
                    { 14, 1, true, 27, 9 },
                    { 8, 1, true, 15, 9 },
                    { 15, 1, true, 29, 9 },
                    { 17, 1, true, 33, 9 },
                    { 18, 1, true, 35, 9 },
                    { 19, 1, true, 37, 9 },
                    { 20, 1, true, 39, 9 },
                    { 21, 1, true, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 22, 1, true, 4, 10 },
                    { 16, 1, true, 31, 9 },
                    { 7, 1, true, 13, 9 },
                    { 6, 1, true, 11, 9 },
                    { 5, 1, true, 9, 9 },
                    { 472, 15, true, 3, 9 },
                    { 471, 15, true, 1, 9 },
                    { 470, 14, true, 40, 10 },
                    { 469, 14, true, 38, 10 },
                    { 468, 14, true, 36, 10 },
                    { 467, 14, true, 34, 10 },
                    { 466, 14, true, 32, 10 },
                    { 465, 14, true, 30, 10 },
                    { 464, 14, true, 28, 10 },
                    { 463, 14, true, 26, 10 },
                    { 462, 14, true, 24, 10 },
                    { 1, 1, true, 1, 9 },
                    { 2, 1, true, 3, 9 },
                    { 3, 1, true, 5, 9 },
                    { 4, 1, true, 7, 9 },
                    { 474, 15, true, 7, 9 },
                    { 589, 17, true, 38, 10 },
                    { 95, 3, true, 50, 9 },
                    { 97, 3, true, 52, 11 },
                    { 538, 16, true, 16, 10 },
                    { 539, 16, true, 18, 10 },
                    { 540, 16, true, 20, 10 },
                    { 541, 16, true, 22, 10 },
                    { 542, 16, true, 24, 10 },
                    { 543, 16, true, 26, 10 },
                    { 537, 16, true, 14, 10 },
                    { 544, 16, true, 28, 10 },
                    { 546, 16, true, 32, 10 },
                    { 547, 16, true, 34, 10 },
                    { 548, 16, true, 36, 10 },
                    { 549, 16, true, 38, 10 },
                    { 550, 16, true, 40, 10 },
                    { 456, 14, true, 12, 10 },
                    { 545, 16, true, 30, 10 },
                    { 536, 16, true, 12, 10 },
                    { 535, 16, true, 10, 10 },
                    { 534, 16, true, 8, 10 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 519, 16, true, 17, 9 },
                    { 520, 16, true, 19, 9 },
                    { 521, 16, true, 21, 9 },
                    { 522, 16, true, 23, 9 },
                    { 523, 16, true, 25, 9 },
                    { 524, 16, true, 27, 9 },
                    { 525, 16, true, 29, 9 },
                    { 526, 16, true, 31, 9 },
                    { 527, 16, true, 33, 9 },
                    { 528, 16, true, 35, 9 },
                    { 529, 16, true, 37, 9 },
                    { 530, 16, true, 39, 9 },
                    { 531, 16, true, 2, 10 },
                    { 532, 16, true, 4, 10 },
                    { 533, 16, true, 6, 10 },
                    { 551, 17, true, 1, 9 },
                    { 518, 16, true, 15, 9 },
                    { 552, 17, true, 3, 9 },
                    { 554, 17, true, 7, 9 },
                    { 574, 17, true, 8, 10 },
                    { 575, 17, true, 10, 10 },
                    { 576, 17, true, 12, 10 },
                    { 577, 17, true, 14, 10 },
                    { 578, 17, true, 16, 10 },
                    { 579, 17, true, 18, 10 },
                    { 573, 17, true, 6, 10 },
                    { 580, 17, true, 20, 10 },
                    { 582, 17, true, 24, 10 },
                    { 583, 17, true, 26, 10 },
                    { 584, 17, true, 28, 10 },
                    { 585, 17, true, 30, 10 },
                    { 586, 17, true, 32, 10 },
                    { 587, 17, true, 34, 10 },
                    { 581, 17, true, 22, 10 },
                    { 572, 17, true, 4, 10 },
                    { 571, 17, true, 2, 10 },
                    { 570, 17, true, 39, 9 },
                    { 555, 17, true, 9, 9 },
                    { 556, 17, true, 11, 9 },
                    { 557, 17, true, 13, 9 },
                    { 558, 17, true, 15, 9 },
                    { 559, 17, true, 17, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 560, 17, true, 19, 9 },
                    { 561, 17, true, 21, 9 },
                    { 562, 17, true, 23, 9 },
                    { 563, 17, true, 25, 9 },
                    { 564, 17, true, 27, 9 },
                    { 565, 17, true, 29, 9 },
                    { 566, 17, true, 31, 9 },
                    { 567, 17, true, 33, 9 },
                    { 568, 17, true, 35, 9 },
                    { 569, 17, true, 37, 9 },
                    { 553, 17, true, 5, 9 },
                    { 96, 3, true, 51, 10 },
                    { 517, 16, true, 13, 9 },
                    { 515, 16, true, 9, 9 },
                    { 116, 4, true, 33, 9 },
                    { 117, 4, true, 34, 10 },
                    { 118, 4, true, 35, 11 },
                    { 119, 4, true, 40, 9 },
                    { 120, 4, true, 41, 10 },
                    { 121, 4, true, 42, 11 },
                    { 115, 4, true, 32, 11 },
                    { 122, 4, true, 43, 9 },
                    { 124, 4, true, 45, 11 },
                    { 125, 4, true, 50, 9 },
                    { 126, 4, true, 51, 10 },
                    { 127, 4, true, 52, 11 },
                    { 128, 4, true, 53, 9 },
                    { 129, 4, true, 54, 10 },
                    { 123, 4, true, 44, 10 },
                    { 114, 4, true, 31, 10 },
                    { 113, 4, true, 30, 9 },
                    { 112, 4, true, 25, 11 },
                    { 98, 3, true, 53, 9 },
                    { 99, 3, true, 54, 10 },
                    { 100, 3, true, 55, 11 },
                    { 459, 14, true, 18, 10 },
                    { 101, 4, true, 10, 9 },
                    { 102, 4, true, 11, 10 },
                    { 103, 4, true, 12, 11 },
                    { 104, 4, true, 13, 9 },
                    { 105, 4, true, 14, 10 },
                    { 106, 4, true, 15, 11 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 107, 4, true, 20, 9 },
                    { 108, 4, true, 21, 10 },
                    { 109, 4, true, 22, 11 },
                    { 110, 4, true, 23, 9 },
                    { 111, 4, true, 24, 10 },
                    { 130, 4, true, 55, 11 },
                    { 458, 14, true, 16, 10 },
                    { 131, 5, true, 10, 9 },
                    { 132, 5, true, 11, 10 },
                    { 151, 5, true, 42, 11 },
                    { 152, 5, true, 43, 9 },
                    { 153, 5, true, 44, 10 },
                    { 154, 5, true, 45, 11 },
                    { 155, 5, true, 50, 9 },
                    { 156, 5, true, 51, 10 },
                    { 157, 5, true, 52, 11 },
                    { 158, 5, true, 53, 9 },
                    { 159, 5, true, 54, 10 },
                    { 160, 5, true, 55, 11 },
                    { 457, 14, true, 14, 10 },
                    { 511, 16, true, 1, 9 },
                    { 512, 16, true, 3, 9 },
                    { 513, 16, true, 5, 9 },
                    { 514, 16, true, 7, 9 },
                    { 150, 5, true, 41, 10 },
                    { 516, 16, true, 11, 9 },
                    { 149, 5, true, 40, 9 },
                    { 147, 5, true, 34, 10 },
                    { 133, 5, true, 12, 11 },
                    { 134, 5, true, 13, 9 },
                    { 135, 5, true, 14, 10 },
                    { 136, 5, true, 15, 11 },
                    { 137, 5, true, 20, 9 },
                    { 138, 5, true, 21, 10 },
                    { 148, 5, true, 35, 11 },
                    { 139, 5, true, 22, 11 },
                    { 141, 5, true, 24, 10 },
                    { 142, 5, true, 25, 11 },
                    { 143, 5, true, 30, 9 },
                    { 144, 5, true, 31, 10 },
                    { 145, 5, true, 32, 11 },
                    { 146, 5, true, 33, 9 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CarriageId", "IsFree", "Number", "SeatTypeId" },
                values: new object[,]
                {
                    { 140, 5, true, 23, 9 },
                    { 446, 14, true, 31, 9 }
                });

            migrationBuilder.InsertData(
                table: "TrainCarriage",
                columns: new[] { "Id", "CarriageId", "TrainId" },
                values: new object[,]
                {
                    { 15, 14, 3 },
                    { 16, 15, 3 },
                    { 5, 12, 1 },
                    { 10, 13, 2 },
                    { 1, 1, 1 },
                    { 7, 3, 2 },
                    { 12, 4, 3 },
                    { 13, 5, 3 },
                    { 17, 16, 3 },
                    { 6, 2, 2 },
                    { 2, 6, 1 },
                    { 3, 7, 1 },
                    { 14, 8, 3 },
                    { 4, 9, 1 },
                    { 8, 10, 2 },
                    { 11, 17, 2 },
                    { 9, 11, 2 }
                });

            migrationBuilder.InsertData(
                table: "TrainStation",
                columns: new[] { "Id", "ArrivalDate", "DepartureDate", "StationId", "TrainId" },
                values: new object[,]
                {
                    { 16, new DateTime(2020, 10, 10, 16, 34, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 36, 0, 0, DateTimeKind.Unspecified), 16, 1 },
                    { 17, new DateTime(2020, 10, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 31, 0, 0, DateTimeKind.Unspecified), 17, 1 },
                    { 18, new DateTime(2020, 10, 10, 17, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 55, 0, 0, DateTimeKind.Unspecified), 18, 1 },
                    { 19, new DateTime(2020, 10, 10, 18, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 22, 0, 0, DateTimeKind.Unspecified), 19, 1 },
                    { 22, new DateTime(2020, 10, 10, 18, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 57, 0, 0, DateTimeKind.Unspecified), 21, 1 },
                    { 23, new DateTime(2020, 10, 10, 19, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 35, 0, 0, DateTimeKind.Unspecified), 22, 1 },
                    { 24, new DateTime(2020, 10, 10, 20, 6, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 9, 0, 0, DateTimeKind.Unspecified), 23, 1 },
                    { 15, new DateTime(2020, 10, 10, 16, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 29, 0, 0, DateTimeKind.Unspecified), 15, 1 },
                    { 21, new DateTime(2020, 10, 10, 18, 46, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 50, 0, 0, DateTimeKind.Unspecified), 20, 1 },
                    { 14, new DateTime(2020, 10, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 16, 7, 0, 0, DateTimeKind.Unspecified), 14, 1 },
                    { 7, new DateTime(2020, 10, 10, 14, 21, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 21, 0, 0, DateTimeKind.Unspecified), 7, 1 },
                    { 12, new DateTime(2020, 10, 10, 15, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 30, 0, 0, DateTimeKind.Unspecified), 12, 1 },
                    { 11, new DateTime(2020, 10, 10, 15, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 18, 0, 0, DateTimeKind.Unspecified), 11, 1 },
                    { 10, new DateTime(2020, 10, 10, 15, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 1, 0, 0, DateTimeKind.Unspecified), 10, 1 },
                    { 9, new DateTime(2020, 10, 10, 14, 42, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 43, 0, 0, DateTimeKind.Unspecified), 9, 1 },
                    { 8, new DateTime(2020, 10, 10, 14, 26, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 27, 0, 0, DateTimeKind.Unspecified), 8, 1 },
                    { 25, new DateTime(2020, 10, 10, 20, 29, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 30, 0, 0, DateTimeKind.Unspecified), 24, 1 },
                    { 6, new DateTime(2020, 10, 10, 14, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 18, 0, 0, DateTimeKind.Unspecified), 6, 1 },
                    { 5, new DateTime(2020, 10, 10, 14, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 13, 0, 0, DateTimeKind.Unspecified), 5, 1 },
                    { 4, new DateTime(2020, 10, 10, 14, 8, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 9, 0, 0, DateTimeKind.Unspecified), 4, 1 },
                    { 3, new DateTime(2020, 10, 10, 14, 4, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 5, 0, 0, DateTimeKind.Unspecified), 3, 1 },
                    { 2, new DateTime(2020, 10, 10, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 14, 1, 0, 0, DateTimeKind.Unspecified), 2, 1 },
                    { 13, new DateTime(2020, 10, 10, 15, 39, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 15, 40, 0, 0, DateTimeKind.Unspecified), 13, 1 }
                });

            migrationBuilder.InsertData(
                table: "TrainStation",
                columns: new[] { "Id", "ArrivalDate", "DepartureDate", "StationId", "TrainId" },
                values: new object[,]
                {
                    { 26, new DateTime(2020, 10, 10, 20, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 39, 0, 0, DateTimeKind.Unspecified), 25, 1 },
                    { 33, new DateTime(2020, 10, 10, 22, 53, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 54, 0, 0, DateTimeKind.Unspecified), 32, 1 },
                    { 28, new DateTime(2020, 10, 10, 21, 35, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 36, 0, 0, DateTimeKind.Unspecified), 27, 1 },
                    { 51, new DateTime(2020, 10, 10, 23, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 57, 0, 0, DateTimeKind.Unspecified), 39, 2 },
                    { 50, new DateTime(2020, 10, 10, 23, 10, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 11, 0, 0, DateTimeKind.Unspecified), 38, 2 },
                    { 49, new DateTime(2020, 10, 10, 22, 31, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 32, 0, 0, DateTimeKind.Unspecified), 37, 2 },
                    { 48, new DateTime(2020, 10, 10, 21, 58, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 59, 0, 0, DateTimeKind.Unspecified), 36, 2 },
                    { 47, new DateTime(2020, 10, 10, 20, 48, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 49, 0, 0, DateTimeKind.Unspecified), 16, 2 },
                    { 46, new DateTime(2020, 10, 10, 20, 25, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 44, 0, 0, DateTimeKind.Unspecified), 15, 2 },
                    { 45, new DateTime(2020, 10, 10, 20, 17, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 20, 19, 0, 0, DateTimeKind.Unspecified), 14, 2 },
                    { 44, new DateTime(2020, 10, 10, 19, 54, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 55, 0, 0, DateTimeKind.Unspecified), 13, 2 },
                    { 43, new DateTime(2020, 10, 10, 19, 43, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 44, 0, 0, DateTimeKind.Unspecified), 12, 2 },
                    { 42, new DateTime(2020, 10, 10, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 31, 0, 0, DateTimeKind.Unspecified), 11, 2 },
                    { 27, new DateTime(2020, 10, 10, 21, 3, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 21, 26, 0, 0, DateTimeKind.Unspecified), 26, 1 },
                    { 41, new DateTime(2020, 10, 10, 19, 13, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 19, 14, 0, 0, DateTimeKind.Unspecified), 10, 2 },
                    { 39, new DateTime(2020, 10, 10, 18, 38, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 39, 0, 0, DateTimeKind.Unspecified), 8, 2 },
                    { 38, new DateTime(2020, 10, 10, 18, 18, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 19, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 37, new DateTime(2020, 10, 10, 17, 32, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 17, 58, 0, 0, DateTimeKind.Unspecified), 1, 2 },
                    { 36, new DateTime(2020, 10, 10, 23, 56, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 59, 0, 0, DateTimeKind.Unspecified), 35, 1 },
                    { 35, new DateTime(2020, 10, 10, 23, 33, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 34, 0, 0, DateTimeKind.Unspecified), 34, 1 },
                    { 34, new DateTime(2020, 10, 10, 23, 1, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 23, 2, 0, 0, DateTimeKind.Unspecified), 33, 1 },
                    { 32, new DateTime(2020, 10, 10, 22, 44, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 45, 0, 0, DateTimeKind.Unspecified), 31, 1 },
                    { 31, new DateTime(2020, 10, 10, 22, 36, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 37, 0, 0, DateTimeKind.Unspecified), 30, 1 },
                    { 30, new DateTime(2020, 10, 10, 22, 23, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 24, 0, 0, DateTimeKind.Unspecified), 29, 1 },
                    { 29, new DateTime(2020, 10, 10, 21, 57, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 22, 59, 0, 0, DateTimeKind.Unspecified), 28, 1 },
                    { 40, new DateTime(2020, 10, 10, 18, 55, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 18, 56, 0, 0, DateTimeKind.Unspecified), 9, 2 },
                    { 1, new DateTime(2020, 10, 10, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 10, 10, 13, 41, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Train_TypeId",
                table: "Train",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train",
                column: "TypeId",
                principalTable: "DictionaryItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Train_DictionaryItems_TypeId",
                table: "Train");

            migrationBuilder.DropTable(
                name: "IdentityUserRole<int>");

            migrationBuilder.DropIndex(
                name: "IX_Train_TypeId",
                table: "Train");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36314aae-5188-4403-92f7-69f6dc28a3ad");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ea103caf-c8b1-40e3-afa3-502c40dd623e");

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Discount",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "RouteStation",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 321);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 322);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 323);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 324);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 325);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 326);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 327);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 328);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 329);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 330);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 331);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 332);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 333);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 334);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 335);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 336);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 337);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 338);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 339);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 340);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 341);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 342);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 343);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 344);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 345);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 346);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 347);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 348);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 349);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 350);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 351);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 352);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 353);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 354);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 355);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 356);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 357);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 358);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 359);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 360);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 361);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 362);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 363);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 364);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 365);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 366);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 367);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 368);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 369);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 370);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 371);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 372);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 373);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 374);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 375);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 376);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 377);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 378);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 379);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 380);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 381);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 382);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 383);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 384);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 385);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 386);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 387);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 388);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 389);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 390);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 391);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 392);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 393);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 394);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 395);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 396);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 397);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 398);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 399);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 400);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 401);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 402);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 403);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 404);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 405);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 406);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 407);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 408);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 409);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 410);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 411);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 412);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 413);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 414);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 415);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 416);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 417);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 418);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 419);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 420);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 421);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 422);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 423);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 424);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 425);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 426);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 427);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 428);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 429);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 430);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 431);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 432);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 433);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 434);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 435);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 436);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 437);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 438);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 439);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 440);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 441);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 442);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 443);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 444);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 445);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 446);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 447);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 448);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 449);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 450);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 451);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 452);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 453);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 454);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 455);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 456);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 457);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 458);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 459);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 460);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 461);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 462);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 463);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 464);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 465);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 466);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 467);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 468);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 469);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 470);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 471);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 472);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 473);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 474);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 475);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 476);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 477);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 478);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 479);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 480);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 481);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 482);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 483);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 484);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 485);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 486);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 487);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 488);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 489);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 490);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 491);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 492);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 493);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 494);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 495);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 496);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 497);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 498);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 499);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 500);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 501);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 502);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 503);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 504);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 505);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 506);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 507);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 508);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 509);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 510);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 511);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 512);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 513);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 514);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 515);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 516);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 517);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 518);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 519);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 520);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 521);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 522);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 523);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 524);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 525);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 526);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 527);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 528);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 529);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 530);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 531);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 532);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 533);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 534);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 535);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 536);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 537);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 538);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 539);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 540);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 541);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 542);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 543);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 544);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 545);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 546);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 547);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 548);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 549);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 550);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 551);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 552);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 553);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 554);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 555);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 556);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 557);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 558);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 559);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 560);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 561);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 562);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 563);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 564);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 565);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 566);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 567);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 568);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 569);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 570);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 571);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 572);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 573);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 574);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 575);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 576);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 577);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 578);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 579);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 580);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 581);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 582);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 583);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 584);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 585);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 586);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 587);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 588);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 589);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "Id",
                keyValue: 590);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrainCarriage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TrainStation",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Carriage",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Route",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Station",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Train",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DictionaryItems",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dictionaries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Train");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Discount");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Train",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Number",
                table: "Carriage",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Carriage",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FreeSeats",
                table: "Carriage",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
