using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using System.Collections;
using System.Windows.Forms;
using System.Data.Common;

namespace WindowsFormsApplication1
{
    public class DbClass : Object
    {
        public int? Id;
        public NpgsqlConnection connection;
        public NpgsqlCommand cmd;
        public NpgsqlDataReader dr;
        public DbClass(NpgsqlConnection AConnection)
        {
            connection = AConnection;
            Clear();
        }
        public virtual void Clear()
        {
            Id = null;
        }
        public virtual bool fnSave()
        {
            return true;
        }

        public virtual bool fnDelete()
        {
            return true;
        }

        public virtual bool fnLoad()
        {
            return true;
        }
        
        public void PrExecuteNonQuery(NpgsqlCommand cmd)
        {
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        public Object PrExecuteScalar(NpgsqlCommand cmd)
        {
            Object Result = null; 
            try
            { 
                Result = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return Result;
        }
        public bool Load()
        {
            connection.Close();
            connection.Open();
            bool Result = fnLoad();
            return Result;
        }

        public bool Save()
        {
            connection.Close();
            connection.Open();
            bool Result = fnSave();
            return Result;
            
        }
        public bool Delete()
        {
            connection.Close();
            connection.Open();
            bool Result = fnDelete();
            return Result;
        }
        public static int FieldByName(NpgsqlDataReader Adr, string AFieldName)
        {
            int Result = -1; 
            for (int i = 0; i< Adr.FieldCount; i++)
            {
                if(Adr.GetName(i).ToUpper() == AFieldName.ToUpper())
                {
                    return i;
                }
            }
            return Result;//  
        }
        public virtual string Select()
        {
            return "";
        }
        public virtual void AssignFromDataset(NpgsqlDataReader ADr)
        {
            //Id = dr.GetInt16();
        }
        public virtual void AssignFromDataGridView(DataGridView ADataGridView)
        {

        }
    }
    public class ListaPracownikow : DbClass
    {

        public ListaPracownikow(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
            Items = new List<Pracownik>();
        }
        public List<Pracownik> Items;
        public Pracownik Item(int Index)
        {
           return Items[Index];
        }
        public override string Select()
        {
            return "select id_001, imie_001, nazwisko_001, login_001, aktywny_001 from public.pracownicy_001";
        }
        public void Add(Pracownik APracownik)
        {
           Items.Add(APracownik);
        }
        public override bool fnLoad()
        {
            Items.Clear();
            cmd = new NpgsqlCommand(Select(), connection);
            dr = cmd.ExecuteReader();
            while (dr.Read()){
                Pracownik pracownik = new Pracownik(connection);
                pracownik.AssignFromDataset(dr);
                Items.Add(pracownik);
            }
            return true;
        }
        public bool fnLoadAvailabledByDate(DateTime ADate)
        {
            //Connect();
            Items.Clear();
            cmd = new NpgsqlCommand("select id_001, imie_001, nazwisko_001, aktywny_001, login_001, t0031.wskaznik_003 as wskaznik_7, t0032.wskaznik_003 as wskaznik_8, "
                                  + "  t0033.wskaznik_003 as wskaznik_9, t0034.wskaznik_003 as wskaznik_10, "
                                  + "(select count(*) from public.harmonogram_005 where id_004_005 = 1  and id_001_005 = id_001)  as dyzury_7, "
                                  + "(select count(*) from public.harmonogram_005 where id_004_005 = 2  and id_001_005 = id_001)  as dyzury_8, "
                                  + "(select count(*) from public.harmonogram_005 where id_004_005 = 3  and id_001_005 = id_001)  as dyzury_9, "
                                  + "(select count(*) from public.harmonogram_005 where id_004_005 = 4  and id_001_005 = id_001)  as dyzury_10, "
                                  + " (select count(*)"
                                  + "  from public.harmonogram_005"
                                  + "  left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003"
                                  + "  where id_001_005 = id_001) as PrzepracowaneDni_005,"
                                  + "  (select COALESCE(sum(wskaznik_003), 0)"
                                  + "  from public.harmonogram_005"
                                  + "  left join public.preferencje_003 on id_001_005 = id_001_003 and id_002_005 = id_002_003 and id_004_005 = id_004_003"
                                  + "  where id_001_005 = id_001) as suma_wskaznik_003"
                                  + "  from public.pracownicy_001"
                                  + "  join dni_robocze_002 on data_002 = @data_002"
                                  + "  join preferencje_003 t0031 on t0031.id_001_003 = id_001 and t0031.id_002_003 = id_002 and t0031.id_004_003 = 1"
                                  + "  join preferencje_003 t0032 on t0032.id_001_003 = id_001 and t0032.id_002_003 = id_002 and t0032.id_004_003 = 2"
                                  + "  join preferencje_003 t0033 on t0033.id_001_003 = id_001 and t0033.id_002_003 = id_002 and t0033.id_004_003 = 3"
                                  + "  join preferencje_003 t0034 on t0034.id_001_003 = id_001 and t0034.id_002_003 = id_002 and t0034.id_004_003 = 4"
                                  + "  left join public.nieobecnosci_006 on ID_001_006 = ID_001 and data_006 = data_002"
                                  + "  where aktywny_001 and ID_006 is null", connection);
            cmd.Parameters.AddWithValue("@data_002", ADate);
            dr = cmd.ExecuteReader();

          
            while (dr.Read())
            {
                Pracownik pracownik = new Pracownik(connection);
                pracownik.AssignFromDatasetWithWskazniki(dr);
                Items.Add(pracownik); 
            }
            return true;
        }

        public int Count()
        {
            return Items.Count;
        }

        
        /*
        public void fnPrepareToGrafikByDate(DateTime ADate)
        {
            fnLoadAvailabledByDate(ADate);
        }
        */
    }

 


    public class Dyzur : DbClass
    {
        public string Opis;
        public int? Obsada;

        public override void Clear()
        {
            Opis = null;
            Obsada = null;
        }
        public Dyzur(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
        }
        public override bool fnSave()
        {

            cmd = new NpgsqlCommand("update public.dyzury_004 set"
                                  + "    obsada_004 = " + Obsada.ToString()
                                  + "  where id_004 = " + Id.ToString() + "; ", connection);
            PrExecuteNonQuery(cmd);
            //cmd.Transaction.Commit();
            //connection.Close();
            return true;
        }
        public override string Select()
        {
            return "select opis_004, obsada_004 from public.dyzury_004";
        }
        public override bool fnLoad()
        {
            cmd = new NpgsqlCommand("select opis_004, obsada_004 from public.dyzury_004"
                                   + "  where id_004 = " + Id.ToString() + "; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                Opis = dr.GetString(0);
                Obsada = dr.GetInt16(1);
            }
            //connection.Close();
            return true;

        }

    }
    public class ObsadaDyzurow : DbClass
    {
        public List<Dyzur> dyzury;
        public ObsadaDyzurow(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
            dyzury = new List<Dyzur>();
            Dyzur dyzur = new Dyzur(AConnection);
            dyzur.Id = 1;
            dyzur.Load();
            dyzury.Add(dyzur);
            dyzur = new Dyzur(AConnection);
            dyzur.Id = 2;
            dyzur.Load();
            dyzury.Add(dyzur);
            dyzur = new Dyzur(AConnection);
            dyzur.Id = 3;
            dyzur.Load();
            dyzury.Add(dyzur);
            dyzur = new Dyzur(AConnection);
            dyzur.Id = 4;
            dyzur.Load();
            dyzury.Add(dyzur);
        }
    }
    public class DzienRoboczy : DbClass
    {
        public DateTime? Data;
        public bool? Ustalone;
        public bool? Roboczy;
        public string DzienTygodnia;
        public override bool fnDelete()
        {
            cmd = new NpgsqlCommand("delete from public.dni_robocze_002"
                                   + "  where id_002 = " + Id.ToString() + "; ", connection);
            PrExecuteNonQuery(cmd);
            return true;

        }
        public override bool fnLoad()
        {
            NpgsqlDataReader dr;
            cmd = new NpgsqlCommand("select id_002, data_002, ustalone_002, roboczy_002, CASE EXTRACT(DOW FROM data_002)"
                 + "    when 1 then 'poniedziałek'"
                 + "    when 2 then 'wtorek'"
                 + "  when 3 then 'środa'"
                 + "  when 4 then 'czwartek'"
                 + "  when 5 then 'piątek'"
                 + "  when 6 then 'sobota'"
                 + "  when 0 then 'niedziela'"
                 + "  else 'nie wiem' end as dzien_tygodnia from public.dni_robocze_002"
                 + "  where id_002 = " + Id.ToString() + "; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                AssignFromDataset(dr);
            }
            //connection.Close();
            return true;

        }
        public DzienRoboczy(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
        }
        public override void Clear()
        {
            Data = null;
            Ustalone = null;
            Roboczy = null;
            DzienTygodnia = null;
        }
        public override string ToString()
        {
            return Data.ToString().Substring(1, 10) + "  " + DzienTygodnia;
        }


        public override bool fnSave()
        {
            if (Id == null)
            {
                cmd = new NpgsqlCommand("insert into public.dni_robocze_002 (data_002, ustalone_002, roboczy_002) values ('"
                                          + Data.ToString() + "', '" + Ustalone.ToString() + "', '" + Roboczy.ToString() + "')", connection);
                Id =  (int)PrExecuteScalar(cmd);
            }
            else
            {
                string test = "update public.dni_robocze_002 set  "
                    + "data_002 = '" + Data.ToString() + "', "
                    + "ustalone_002 = " + Ustalone.ToString() + ", "
                    + "roboczy_002 = " + Roboczy.ToString()
                    + "  where id_002 = " + Id.ToString();
                cmd = new NpgsqlCommand("update public.dni_robocze_002 set  "
                    + "data_002 = '" + Data.ToString() + "', "
                    + "ustalone_002 = " + Ustalone.ToString() + ", "
                    + "roboczy_002 = " + Roboczy.ToString()
                    + "  where id_002 = '" + Id.ToString() + "'", connection);
                PrExecuteNonQuery(cmd);
            }
            //cmd.Transaction.Commit();
            //connection.Close();
            return true;
        }
        public override void AssignFromDataset(NpgsqlDataReader ADr)
        {
            Id = ADr.GetInt32(FieldByName(ADr, "id_002"));
            Data = ADr.GetDateTime(FieldByName(ADr, "data_002"));
            Ustalone = ADr.GetBoolean(FieldByName(ADr, "ustalone_002"));
            Roboczy = ADr.GetBoolean(FieldByName(ADr, "roboczy_002"));
            DzienTygodnia = ADr.GetString(FieldByName(ADr, "dzien_tygodnia"));
        }
        public override void AssignFromDataGridView(DataGridView ADataGridView)
        {
            Id = int.Parse(ADataGridView.CurrentRow.Cells["id_002"].Value.ToString());
            Data = DateTime.Parse(ADataGridView.CurrentRow.Cells["data_002"].Value.ToString());
            Ustalone = bool.Parse(ADataGridView.CurrentRow.Cells["ustalone_002"].Value.ToString());
            Roboczy = bool.Parse(ADataGridView.CurrentRow.Cells["roboczy_002"].Value.ToString());
            DzienTygodnia = ADataGridView.CurrentRow.Cells["dzien_tygodnia_002"].Value.ToString();
        }
    }
    public class ListaDniRoboczych : DbClass
    {

        public ListaDniRoboczych(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
            Items = new List<DzienRoboczy>();
        }
        public List<DzienRoboczy> Items;
        public DzienRoboczy Item(int Index)
        {
            return Items[Index];
        }
        public override string Select()
        {
            return "select id_002, data_002, ustalone_002, roboczy_002, CASE EXTRACT(DOW FROM data_002)"
                 + "    when 1 then 'poniedziałek'"
                 + "    when 2 then 'wtorek'"
                 + "  when 3 then 'środa'"
                 + "  when 4 then 'czwartek'"
                 + "  when 5 then 'piątek'"
                 + "  when 6 then 'sobota'"
                 + "  when 0 then 'niedziela'"
                 + "  else 'nie wiem' end as dzien_tygodnia from public.dni_robocze_002"
                 + "  order by data_002";
        }
        public void Add(DzienRoboczy ADzienRoboczy)
        {
            Items.Add(ADzienRoboczy);
        }
        public override bool fnLoad()
        {
            Items.Clear();
            cmd = new NpgsqlCommand(Select(), connection);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DzienRoboczy dzienRoboczy = new DzienRoboczy(connection);
                dzienRoboczy.AssignFromDataset(dr);
                Items.Add(dzienRoboczy);
            }
            return true;
        }
        public int Count()
        {
            return Items.Count;
        }
    }

     public class Harmonogram: DbClass
    {
        //public int? Id;
        public int? Id001;
        public int? Id002;
        public int? Id004;
        public bool? Recznie;
        public override void Clear()
        {
            Id = null;
            Id001 = null;
            Id002 = null;
            Id004 = null;
            Recznie = null;
        }
        public Harmonogram(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
        }

        public override bool fnDelete()
        {
            cmd = new NpgsqlCommand("delete from public.harmonogram_005"
                                   + "  where id_005 = " + Id.ToString() + "; ", connection);
            PrExecuteNonQuery(cmd);
            return true;

        }
        public override bool fnSave()
        {
            if (Id == null)
            {
                cmd = new NpgsqlCommand("insert into public.harmonogram_005 (id_001_005, id_002_005, id_004_005, recznie_005) values ("
                                          + Id001.ToString() + ", " + Id002.ToString() + ", " + Id004.ToString() + ", '" + Recznie.ToString() + "' returning id_005)", connection);
                Id = (int)PrExecuteScalar(cmd); 
            }
            else
            {
                cmd = new NpgsqlCommand("update public.harmonogram_005 set  "
                    + "id_001_005 = " + Id001.ToString() + ", "
                    + "id_002_005 = " + Id002.ToString() + ", "
                    + "id_004_005 = " + Id004.ToString() + ", "
                    + "recznie_005 = '" + Recznie.ToString()
                    + "'  where id_005 = " + Id.ToString(), connection);
                PrExecuteNonQuery(cmd);
            }
            //cmd.Transaction.Commit();
            //connection.Close();
            return true;
        }
        public override void AssignFromDataset(NpgsqlDataReader ADr)
        {
            Id = ADr.GetInt16(FieldByName(ADr, "id_005"));
            Id001 = ADr.GetInt16(FieldByName(ADr, "id_001_005"));
            Id002 = ADr.GetInt16(FieldByName(ADr, "id_002_005"));
            Id004 = ADr.GetInt16(FieldByName(ADr, "id_004_005"));
            Recznie = ADr.GetBoolean(FieldByName(ADr, "recznie_001"));
        }
        public override void AssignFromDataGridView(DataGridView ADataGridView)
        {
            Id = int.Parse(ADataGridView.CurrentRow.Cells["id_005"].Value.ToString());
            Id001 = int.Parse(ADataGridView.CurrentRow.Cells["id_001_005"].Value.ToString());
            Id002 = int.Parse(ADataGridView.CurrentRow.Cells["id_002_005"].Value.ToString());
            Id004 = int.Parse(ADataGridView.CurrentRow.Cells["id_004_005"].Value.ToString());
            Recznie = bool.Parse(ADataGridView.CurrentRow.Cells["recznie_005"].FormattedValue.ToString());
        }

        public override string Select()
        {
            return "select opis_004, obsada_004 from public.dyzury_004";
        }
        public override bool fnLoad()
        {
            cmd = new NpgsqlCommand("select id_005, id_001_005, id_002_005, id_004_005, recznie_005 from public.harmonogramy_005"
                                   + "  where id_005 = " + Id.ToString() + "; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                AssignFromDataset(dr);
            }
            //connection.Close();
            return true;

        }

    }

    public class Nieobecnosc: DbClass
    {

        public int? Id001;
        public DateTime? Data;
        public DateTime? DataDo;
        public bool? Zatwierdzone;
        public int? Typ;
        public String TypOpis{
            get
            {
                switch (Typ)
                {
                    case 0:
                        return "Urlop";
                    case 1:
                        return "Choroba";
                    case 2:
                        return "Wyjazd";
                    case 3:
                        return "Szkolenie";
                    default:
                        return "Nieokreślone";
                }
            }  
        }

        public override bool fnDelete()
        {
            cmd = new NpgsqlCommand("delete from public.nieobecnosci_006"
                                   + "  where id_006 = " + Id.ToString() + "; ", connection);
            PrExecuteNonQuery(cmd);
            return true;

        }

        public Nieobecnosc(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
        }
        public override void Clear()
        {
            Id001 = null;
            Data = null;
            DataDo = null;
            Zatwierdzone = null;
            Typ = null;
            
        }
        public override string ToString()
        {
            return Data.ToString() + "  " + Zatwierdzone + "Zatwierdzone" + " ";
        }

        public override string Select()
        {
            return "select  id_006, id_001_006, data_006, zatwierdzone_006, typ_006 from public.nieobecnosci_006";
        }

        public override void AssignFromDataset(NpgsqlDataReader ADr)
        {
            
            Id = ADr.GetInt16(FieldByName(ADr, "id_006"));
            Id001 = ADr.GetInt16(FieldByName(ADr, "id_001_006"));
            Data = ADr.GetDateTime(FieldByName(ADr, "data_006"));
            DataDo = Data;
            Typ = ADr.GetInt16(FieldByName(ADr, "typ_006"));
            Zatwierdzone = ADr.GetBoolean(FieldByName(ADr, "zatwierdzone_006"));
        }
        public override void AssignFromDataGridView(DataGridView ADataGridView)
        {
            Id = int.Parse(ADataGridView.CurrentRow.Cells["id_006"].Value.ToString());
            Id001 = int.Parse(ADataGridView.CurrentRow.Cells["id_001_006"].Value.ToString());
            Data = DateTime.Parse(ADataGridView.CurrentRow.Cells["data_006"].Value.ToString());
            DataDo = Data;
            if (ADataGridView.CurrentRow.Cells["typ_006"].Value.ToString() == "")
                Typ = null;
            else
                Typ = int.Parse(ADataGridView.CurrentRow.Cells["typ_006"].Value.ToString());
            if (ADataGridView.CurrentRow.Cells["zatwierdzone_006"].Value.ToString() != "")
                Zatwierdzone = Boolean.Parse(ADataGridView.CurrentRow.Cells["zatwierdzone_006"].Value.ToString());
            else
                Zatwierdzone = false;
        }


        public override bool fnSave()
        {
            if (Id != null)
            {
                cmd = new NpgsqlCommand("update public.nieobecnosci_006 set"
                                      + "    zatwierdzone_006 = '" + Zatwierdzone.ToString() + "', "
                                      + "    typ_006 = " + Typ.ToString() + ", "
                                      + "    data_006 = '" + Data.ToString() + "'"
                                      + "  where id_006 = " + Id.ToString() + "; ", connection);
                PrExecuteNonQuery(cmd);
            }
            else
            {
                cmd = new NpgsqlCommand("insert into public.nieobecnosci_006 (id_001_006, data_006, zatwierdzone_006, typ_006) values (" + Id001.ToString() + ", '"
                                            + Data.ToString() + "', '" + Zatwierdzone.ToString() + "', "
                                            + Typ.ToString() + ") returning id_006", connection);

                Id = (int)PrExecuteScalar(cmd);

            }
            return true;
        }
        public void Assign(Nieobecnosc ANieobecnosc)
        {
            Id = ANieobecnosc.Id;
            Id001 = ANieobecnosc.Id001;
            Data = ANieobecnosc.Data;
            Zatwierdzone = ANieobecnosc.Zatwierdzone;
            Typ = ANieobecnosc.Typ;
        }
        public override bool fnLoad()
        {
            NpgsqlDataReader dr;
            cmd = new NpgsqlCommand("select  id_006, id_001_006, data_006, zatwierdzone_006, typ_006 from public.nieobecnosci_006"
                                   + "  where id_006 = " + Id.ToString() + "; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                AssignFromDataset(dr);
            }
            return true;

        }
        
    }
    public class Pracownik : DbClass
    {
        public string Imie;
        public string Nazwisko;
        public string Login;
        public bool? Aktywny;
        public int PrzepracowaneDni;
        public decimal SumaWskaznik;
        public int Dyzury7;
        public int Dyzury8;
        public int Dyzury9;
        public int Dyzury10;
        public decimal Wskaznik7;
        public decimal Wskaznik8;
        public decimal Wskaznik9;
        public decimal Wskaznik10;
        public Pracownik(NpgsqlConnection AConnection) : base(AConnection)
        {
            new DbClass(AConnection);
        }
        public override void Clear()
        {
            Id = null;
            Nazwisko = null;
            Imie = null;
            Login = null;
            Aktywny = null;
        }
        public override string ToString()
        {
            return Nazwisko + " " + Imie;
        }
        public override string Select()
        {
            return "select id_001, imie_001, nazwisko_001, login_001, aktwny_001 from public.pracownicy_001";
        }

        public bool UserExists()
        {   
            bool Result = false;
            NpgsqlDataReader dr;
            cmd = new NpgsqlCommand("select count(*) from pg_catalog.pg_user  where usename = '"  + Login.ToString() + "'; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read() && (dr.GetInt16(0) == 1)) 
            {
                return true;
            }
            connection.Close();
            connection.Open();
            return Result;
        }

        public void CreateUser(String APassword, String ARole)
        {
            if ((Login != "") && (APassword != ""))
            {
                cmd = new NpgsqlCommand("create role " + Login + " inherit noreplication login password '" + APassword + "'; ", connection);
                PrExecuteNonQuery(cmd);
                connection.Close();
                connection.Open();
                if (ARole != "")
                {
                    cmd = new NpgsqlCommand("grant " + ARole + " to " + Login + ";", connection);
                    PrExecuteNonQuery(cmd);
                    connection.Close();
                    connection.Open();
                }
            }
        }
        public void ChangePassword(String APassword)
        {
            if ((Login != "") && (APassword != ""))
            {
                cmd = new NpgsqlCommand("alter role " + Login + " password '" + APassword + "'; ", connection);
                PrExecuteNonQuery(cmd);
                connection.Close();
                connection.Open();

            }
        }

        public override bool fnSave()
        {
            if (Id != null)
            {
                cmd = new NpgsqlCommand("update public.pracownicy_001 set"
                                      + "    imie_001 = '" + Imie.ToString() + "', "
                                      + "    nazwisko_001 = '" + Nazwisko.ToString() + "', "
                                      + "    login_001 = '" + Login.ToString() + "', "
                                      + "    aktywny_001 = '" + Aktywny.ToString() + "'"
                                      + "  where id_001 = " + Id.ToString() + "; ", connection);

                PrExecuteNonQuery(cmd);
            }
            else
            {
                cmd = new NpgsqlCommand("insert into public.pracownicy_001 (imie_001, nazwisko_001, login_001, aktywny_001) values ('" + Imie.ToString() + "', '"
                                            + Nazwisko.ToString() + "', '" + Login.ToString() + "', '"
                                            + Aktywny.ToString() + "') returning id_001", connection);

                Id = (int)PrExecuteScalar(cmd);

            }
                //cmd.Transaction.Commit();
            //connection.Close();
            return true;
        }
        public void Assign(Pracownik APracownik)
        {
          Id = APracownik.Id; 
          Imie = APracownik.Imie;
          Nazwisko = APracownik.Nazwisko;
          Aktywny = APracownik.Aktywny;
          PrzepracowaneDni = APracownik.PrzepracowaneDni;
          SumaWskaznik = APracownik.SumaWskaznik;
            
          Dyzury7 = APracownik.Dyzury7;
          Dyzury8 = APracownik.Dyzury8;
          Dyzury9 = APracownik.Dyzury9;
          Dyzury10 = APracownik.Dyzury10;
          Wskaznik7 = APracownik.Wskaznik7;
          Wskaznik8 = APracownik.Wskaznik8;
          Wskaznik9 = APracownik.Wskaznik9;
          Wskaznik10 = APracownik.Wskaznik10;
        }
        public override bool fnLoad()
        {
            NpgsqlDataReader dr;
            cmd = new NpgsqlCommand("select id_001, imie_001, nazwisko_001, login_001, aktywny_001 from public.pracownicy_001"
                                   + "  where id_001 = " + Id.ToString() + "; ", connection);
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                AssignFromDataset(dr);
            }
            //connection.Close();
            return true;

        }

        public override bool fnDelete()
        {
            cmd = new NpgsqlCommand("delete from public.pracownicy_001"
                                   + "  where id_001 = " + Id.ToString() + "; ", connection);
            PrExecuteNonQuery(cmd);
            return true;

        }
               public void AssignFromDatasetWithWskazniki(NpgsqlDataReader ADr)
        {
            Id = ADr.GetInt16(FieldByName(ADr, "id_001"));
            Imie = ADr.GetString(FieldByName(ADr, "imie_001"));
            Nazwisko = ADr.GetString(FieldByName(ADr, "nazwisko_001"));
            Login = ADr.GetString(FieldByName(ADr, "login_001"));
            Aktywny = ADr.GetBoolean(FieldByName(ADr, "aktywny_001"));
            Wskaznik7 = ADr.GetDecimal(FieldByName(ADr, "wskaznik_7"));
            Wskaznik8 = ADr.GetDecimal(FieldByName(ADr, "wskaznik_8"));
            Wskaznik9 = ADr.GetDecimal(FieldByName(ADr, "wskaznik_9"));
            Wskaznik10 = ADr.GetDecimal(FieldByName(ADr, "wskaznik_10"));
            Dyzury7 = ADr.GetInt32(FieldByName(ADr, "dyzury_7"));
            Dyzury8 = ADr.GetInt32(FieldByName(ADr, "dyzury_8"));
            Dyzury9 = ADr.GetInt32(FieldByName(ADr, "dyzury_9"));
            Dyzury10 = ADr.GetInt32(FieldByName(ADr, "dyzury_10"));
            PrzepracowaneDni = ADr.GetInt16(FieldByName(ADr, "PrzepracowaneDni_005"));
            SumaWskaznik = ADr.GetDecimal(FieldByName(ADr, "suma_wskaznik_003"));
            Console.WriteLine(ToString() + "; PrzepracowaneDni: "  + PrzepracowaneDni.ToString() + "; SumaWskaznik: " + SumaWskaznik.ToString());
        }
        public override void AssignFromDataset(NpgsqlDataReader ADr)
        {
            Id = ADr.GetInt16(FieldByName(ADr, "id_001"));
            Imie = ADr.GetString(FieldByName(ADr, "imie_001"));
            Nazwisko = ADr.GetString(FieldByName(ADr, "nazwisko_001"));
            Login = ADr.GetString(FieldByName(ADr, "login_001"));
            Aktywny = ADr.GetBoolean(FieldByName(ADr, "aktywny_001"));
        }
        public override void AssignFromDataGridView(DataGridView ADataGridView)
        {
            Id = int.Parse(ADataGridView.CurrentRow.Cells["id_001"].Value.ToString());
            Imie = ADataGridView.CurrentRow.Cells["imie_001"].FormattedValue.ToString();
            Nazwisko = ADataGridView.CurrentRow.Cells["nazwisko_001"].FormattedValue.ToString();
            Login = ADataGridView.CurrentRow.Cells["login_001"].FormattedValue.ToString();
            Aktywny = bool.Parse(ADataGridView.CurrentRow.Cells["aktywny_001"].FormattedValue.ToString());            
        }
    }
    public class Grafik : DbClass //Klasa zawierająca jakieś rozwiązanie: pracowników na 7, pracoeników na 8 itd oraz potrafiąca zapisać rozwiązanie w bazie
    {
        public DateTime Data;
        public int Id002;
        public ListaPracownikow listaPracownikow7;
        public ListaPracownikow listaPracownikow8;
        public ListaPracownikow listaPracownikow9;
        public ListaPracownikow listaPracownikow10;

        public override bool fnSave()
        {
            int ii;
            Pracownik pracownik;
            cmd = new NpgsqlCommand("delete from public.harmonogram_005 where id_002_005 = @id_002_005", connection);
            cmd.Parameters.AddWithValue("@id_002_005", Id002);
            PrExecuteNonQuery(cmd);

            cmd = new NpgsqlCommand("insert into public.harmonogram_005( id_001_005, id_002_005, id_004_005, recznie_005) values(@id_001_005, @id_002_005, @id_004_005, @recznie_005)", connection);
            
            for (ii = 0; ii < listaPracownikow7.Count(); ii++)
            {
                pracownik = listaPracownikow7.Item(ii);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_002_005", Id002);
                cmd.Parameters.AddWithValue("@id_004_005", 1);
                cmd.Parameters.AddWithValue("@recznie_005", true);
                cmd.Parameters.AddWithValue("@id_001_005", pracownik.Id);
                PrExecuteNonQuery(cmd);
            }

            for (ii = 0; ii < listaPracownikow8.Count(); ii++)
            {
                pracownik = listaPracownikow8.Item(ii);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_002_005", Id002);
                cmd.Parameters.AddWithValue("@id_004_005", 2);
                cmd.Parameters.AddWithValue("@recznie_005", true);
                cmd.Parameters.AddWithValue("@id_001_005", pracownik.Id);
                PrExecuteNonQuery(cmd);
            }
            for (ii = 0; ii < listaPracownikow9.Count(); ii++)
            {
                pracownik = listaPracownikow9.Item(ii);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_002_005", Id002);
                cmd.Parameters.AddWithValue("@id_004_005", 3);
                cmd.Parameters.AddWithValue("@recznie_005", true);
                cmd.Parameters.AddWithValue("@id_001_005", pracownik.Id);
                PrExecuteNonQuery(cmd);
            }
            for (ii = 0; ii < listaPracownikow10.Count(); ii++)
            {
                pracownik = listaPracownikow10.Item(ii);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_002_005", Id002);
                cmd.Parameters.AddWithValue("@id_004_005", 4);
                cmd.Parameters.AddWithValue("@recznie_005", true);
                cmd.Parameters.AddWithValue("@id_001_005", pracownik.Id);
                PrExecuteNonQuery(cmd);
            }
            cmd = new NpgsqlCommand("update public.dni_robocze_002"
                         + "  set ustalone_002 = TRUE"
                         + "  where id_002 = @id_002", connection);
            cmd.Parameters.AddWithValue("@id_002", Id002);
            PrExecuteNonQuery(cmd);
            //cmd.Transaction.Commit();
            //connection.Close();
            return true;
        }
        public void Assign(Grafik AGrafik)
        {
            int ii;
            //Console.WriteLine("7");
            for (ii = 0; ii < AGrafik.listaPracownikow7.Count(); ii++)
            {
                listaPracownikow7.Item(ii).Assign(AGrafik.listaPracownikow7.Item(ii));
                //Console.WriteLine(listaPracownikow7.Item(ii).ToString());
            }
            //Console.WriteLine("8");
            for (ii = 0; ii < AGrafik.listaPracownikow8.Count(); ii++)
            {
                listaPracownikow8.Item(ii).Assign(AGrafik.listaPracownikow8.Item(ii));
                //Console.WriteLine(listaPracownikow8.Item(ii).ToString());
            }
            //Console.WriteLine("9");
            for (ii = 0; ii < AGrafik.listaPracownikow9.Count(); ii++)
            {
                listaPracownikow9.Item(ii).Assign(AGrafik.listaPracownikow9.Item(ii));
                //Console.WriteLine(listaPracownikow9.Item(ii).ToString());
            }
            //Console.WriteLine("10");
            for (ii = 0; ii < AGrafik.listaPracownikow10.Count(); ii++)
            {
                listaPracownikow10.Item(ii).Assign(AGrafik.listaPracownikow10.Item(ii));
                //Console.WriteLine(listaPracownikow10.Item(ii).ToString());
            }
            for (ii = 0; ii < AscendingListZadowolenia.Count(); ii++)
            {
                AscendingListZadowolenia[ii] = AGrafik.AscendingListZadowolenia[ii];
            }
            for (ii = 0; ii < AscendingListNajrzadszeDyzury.Count(); ii++)
            {
                AscendingListNajrzadszeDyzury[ii] = AGrafik.AscendingListNajrzadszeDyzury[ii];
            }

        }
        public int InsertByOrder(List<decimal> AList, decimal AItem, bool AUnique = false) 
        {
            int Result = 0;
            int iIndex, L, H, I; 
            iIndex= -1;
            L= 0;
            H= AList.Count - 1;
            while (L <= H)
            {
              I = (L + H) >> 1;
              if (AList[I] < AItem)
                L = I + 1;
              else
              {
                H = I - 1;
                if (AList[I] == AItem)
                {
                    Result= -1;
                    L= I;
                }
              }
            }
            if (Result > 0 || ! AUnique)
            {
                iIndex = L;
                AList.Insert(iIndex, AItem);
            }
            return Result;
        }

        public void AssignFromDoUsuniecia(Grafik AGrafik)
        {
            listaPracownikow7.Items.Clear();
            listaPracownikow8.Items.Clear();
            listaPracownikow9.Items.Clear();
            listaPracownikow10.Items.Clear();
            for (int ii = 0; ii < AGrafik.listaPracownikow7.Count(); ii++)
            {
                listaPracownikow7.Add(AGrafik.listaPracownikow7.Item(ii));
            }
            for (int ii = 0; ii < AGrafik.listaPracownikow8.Count(); ii++)
            {
                listaPracownikow8.Add(AGrafik.listaPracownikow8.Item(ii));
            }

            for (int ii = 0; ii < AGrafik.listaPracownikow9.Count(); ii++)
            {
                listaPracownikow9.Add(AGrafik.listaPracownikow9.Item(ii));
            }
            for (int ii = 0; ii < AGrafik.listaPracownikow10.Count(); ii++)
            {
                listaPracownikow10.Add(AGrafik.listaPracownikow10.Item(ii));
            }

        }
        public Grafik(NpgsqlConnection AConnection) : base(AConnection)
        {
            listaPracownikow7 = new ListaPracownikow(AConnection);
            listaPracownikow8 = new ListaPracownikow(AConnection);
            listaPracownikow9 = new ListaPracownikow(AConnection);
            listaPracownikow10 = new ListaPracownikow(AConnection);
            AscendingListZadowolenia = new List<decimal>();
            AscendingListNajrzadszeDyzury = new List<decimal>();


        }
        
        public List<decimal> AscendingListZadowolenia;
        public List<decimal> AscendingListNajrzadszeDyzury;

        public void BuildAscendingLists()
        {
            decimal dSatisfaction;
            decimal dRarest;
            AscendingListZadowolenia.Clear();
            AscendingListNajrzadszeDyzury.Clear();
            for (int ii = 0; ii < listaPracownikow7.Count(); ii++)
            {
                dSatisfaction = ((listaPracownikow7.Item(ii).SumaWskaznik) + listaPracownikow7.Item(ii).Wskaznik7) / (listaPracownikow7.Item(ii).PrzepracowaneDni + 1);
                dRarest = (listaPracownikow7.Item(ii).PrzepracowaneDni + 1) / ((listaPracownikow7.Item(ii).Dyzury7) + 1);
                InsertByOrder(AscendingListZadowolenia, dSatisfaction);
                InsertByOrder(AscendingListNajrzadszeDyzury, dRarest);
            }
            for (int ii = 0; ii < listaPracownikow8.Count(); ii++)
            {
                dSatisfaction = ((listaPracownikow8.Item(ii).SumaWskaznik) + listaPracownikow8.Item(ii).Wskaznik8) / (listaPracownikow8.Item(ii).PrzepracowaneDni + 1);
                dRarest = (listaPracownikow8.Item(ii).PrzepracowaneDni + 1) / ((listaPracownikow8.Item(ii).Dyzury8) + 1);
                InsertByOrder(AscendingListZadowolenia, dSatisfaction);
                InsertByOrder(AscendingListNajrzadszeDyzury, dRarest);
            }
            for (int ii = 0; ii < listaPracownikow9.Count(); ii++)
            {
                dSatisfaction = ((listaPracownikow9.Item(ii).SumaWskaznik) + listaPracownikow9.Item(ii).Wskaznik9) / (listaPracownikow9.Item(ii).PrzepracowaneDni + 1);
                dRarest = (listaPracownikow9.Item(ii).PrzepracowaneDni + 1) / ((listaPracownikow9.Item(ii).Dyzury9) + 1);
                InsertByOrder(AscendingListZadowolenia, dSatisfaction);
                InsertByOrder(AscendingListNajrzadszeDyzury, dRarest);
            }
            for (int ii = 0; ii < listaPracownikow10.Count(); ii++)
            {
                dSatisfaction = ((listaPracownikow10.Item(ii).SumaWskaznik) + listaPracownikow10.Item(ii).Wskaznik10) / (listaPracownikow10.Item(ii).PrzepracowaneDni + 1);
                dRarest = (listaPracownikow10.Item(ii).PrzepracowaneDni + 1) / ((listaPracownikow10.Item(ii).Dyzury10) + 1);
                InsertByOrder(AscendingListZadowolenia, dSatisfaction);
                InsertByOrder(AscendingListNajrzadszeDyzury, dRarest);
            }
            String sLine = "";
            for(int ii = 0; ii < AscendingListZadowolenia.Count(); ii++)
            {
                sLine = sLine + AscendingListZadowolenia[ii].ToString() + ";";
            }
        }
        public bool IsBeterThan(Grafik AGrafik)
        {
           
            BuildAscendingLists();
            for (int ii = 0; ii < AscendingListZadowolenia.Count(); ii++)
            {
                if (AscendingListZadowolenia.ElementAt(ii) < AGrafik.AscendingListZadowolenia.ElementAt(ii))
                {
                    return false;
                }

                if (AscendingListZadowolenia. ElementAt(ii) > AGrafik.AscendingListZadowolenia.ElementAt(ii))
                {
                    return true;
                }
            }
            for (int ii = 0; ii < AscendingListNajrzadszeDyzury.Count(); ii++)
            {
                if (AscendingListNajrzadszeDyzury.ElementAt(ii) < AGrafik.AscendingListNajrzadszeDyzury.ElementAt(ii))
                {
                    return false;
                }
                if (AscendingListNajrzadszeDyzury.ElementAt(ii) > AGrafik.AscendingListNajrzadszeDyzury.ElementAt(ii))
                {
                    return true;
                }
            }
            return false;
        }       
    }
}
