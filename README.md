Emlak Otomasyonu
sınav klasörünün içindeki Kiralama_otomasyon.bak dosyasını kurmamız lazım adımlar :
1-Adım> sql server management studio uygulamasını açın
2-Adım> databases klasörüne sag tıklayın
3-Adım> restore database seçenegini seçin
4-Adım> device comboboxunu işaretleyin
5-Adım> device yazısının önündeki ... tıklayın
6-Adım> add seçenegini seçin 
7-Adım> kiralama_otomasyon.bak dosyasını seçin ve 3 kez enter

SqlConnection baglanti = new SqlConnection("Server=bilgisayar_ismi;Database=kiralama_otomasyon;Integrated Security=True;");
kodunu degiştirin
