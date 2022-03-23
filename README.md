# folder-crawler
Aplikasi Desktop Folder Crawler dengan BFS dan DFS untuk Tugas Besar 2 Strategi Algoritma

## Deskripsi Singkat Program
Program ini merupakan program pencarian folder berupa Aplikasi Desktop Folder Crawler dengan pengaplikasian algoritma Breadth First Search dan Depth First Search dalam pencarian suatu solusinya.

## Requirement Program dan Instalasi Module/Package
- Visual Studio dengan .NET untuk C#
- NuGet Package untuk MSAGL
- Library MSAGL

Instalasi:
1. Install Visual Studio beserta .NET untuk C# dengan mengikuti proses instalasi standar aplikasi.
2. Install NuGet Package dari repo GitHub: https://github.com/microsoft/automatic-graph-layout dengan Package Manager yang ada di menu Tools > NuGet Package Manager > Package Manager Console. Package Manager Console akan muncul di bagian bawah layar.
3. Install library MSAGL dengan menggunakan command berikut pada Package Manager Console:
```
Install-Package AutomaticGraphLayout -Version 1.1.11
Install-Package AutomaticGraphLayout.Drawing -Version 1.1.11
Install-Package AutomaticGraphLayout.WpfGraphControl -Version 1.1.11
Install-Package AutomaticGraphLayout.GraphViewerGDI -Version 1.1.11
```

## Cara menggunakan program
1. Jalankan program dengan melakukan Run/Start program.
2. Setelah tampilan aplikasi muncul, tekan tombol "Choose Folder" dan pilih Starting Folder.
3. Masukkan filename yang ingin dicari.
4. (Opsional) Toggle "Find All Occurences" bila ingin mendapatkan seluruh hasil dari filename yang dicari.
5. Pilih salah satu method (BFS atau DFS).
6. Klik search file untuk melakukan pencarian. Dapat dilakukan cancel search pada saat pencarian sedang dilakukan.
7. User dapat membuka file explorer melalui hyperlink yang ditampilkan di bawah hasil graf pohon.

## Author / identitas pembuat
Kelompok: DeepFujoSearch
- 13520079 Ghebyon Tohada Nainggolan
- 13520127 Adzka Ahmadetya Zaidan
- 13520157 Thirafi Najwan Kurniatama