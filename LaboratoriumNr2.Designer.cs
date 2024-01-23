namespace Projekt2_Karwowski65859
{
    partial class LaboratoriumNr2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.chbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.lblWyborFigury = new System.Windows.Forms.Label();
            this.lblN = new System.Windows.Forms.Label();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider2 = new System.Windows.Forms.ErrorProvider(this.components);
            this.lblGrubosc = new System.Windows.Forms.Label();
            this.numericGrubosc = new System.Windows.Forms.NumericUpDown();
            this.btnPrzesuniecieBezZmian = new System.Windows.Forms.Button();
            this.btnZmienKolorTla = new System.Windows.Forms.Button();
            this.btnWziernikKoloruLinii = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.btnZmienKolorLinii = new System.Windows.Forms.Button();
            this.lblWziernikKoloruLinii = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblZmienStylLinii = new System.Windows.Forms.Label();
            this.comboBoxStylLinii = new System.Windows.Forms.ComboBox();
            this.btnPrzesuniecieZeZmianami = new System.Windows.Forms.Button();
            this.btnNowaFigura = new System.Windows.Forms.Button();
            this.lblNarzedzia = new System.Windows.Forms.Label();
            this.btnWlaczPrezentacje = new System.Windows.Forms.Button();
            this.txtIndeksFigury = new System.Windows.Forms.TextBox();
            this.lblIndeksFigury = new System.Windows.Forms.Label();
            this.btnPoprzedni = new System.Windows.Forms.Button();
            this.btnNastepny = new System.Windows.Forms.Button();
            this.btnWylaczPrezentacje = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBarX = new System.Windows.Forms.TrackBar();
            this.txtX = new System.Windows.Forms.TextBox();
            this.trackBarY = new System.Windows.Forms.TrackBar();
            this.txtY = new System.Windows.Forms.TextBox();
            this.lblUstawNoweWspolrzedne = new System.Windows.Forms.Label();
            this.lblX = new System.Windows.Forms.Label();
            this.lblY = new System.Windows.Forms.Label();
            this.btnPrzesunLosowoBezZmian = new System.Windows.Forms.Button();
            this.btnPrzesunLosowoZeZmianami = new System.Windows.Forms.Button();
            this.btnPowrot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrubosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).BeginInit();
            this.SuspendLayout();
            // 
            // pbRysownica
            // 
            this.pbRysownica.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pbRysownica.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbRysownica.Location = new System.Drawing.Point(204, 31);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(674, 418);
            this.pbRysownica.TabIndex = 0;
            this.pbRysownica.TabStop = false;
            // 
            // chbFiguryGeometryczne
            // 
            this.chbFiguryGeometryczne.FormattingEnabled = true;
            this.chbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrag",
            "Prostokat",
            "Kwadrat",
            "Elipsa Wypelniana"});
            this.chbFiguryGeometryczne.Location = new System.Drawing.Point(896, 188);
            this.chbFiguryGeometryczne.Name = "chbFiguryGeometryczne";
            this.chbFiguryGeometryczne.Size = new System.Drawing.Size(161, 124);
            this.chbFiguryGeometryczne.TabIndex = 1;
            // 
            // lblWyborFigury
            // 
            this.lblWyborFigury.AutoSize = true;
            this.lblWyborFigury.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblWyborFigury.Location = new System.Drawing.Point(884, 141);
            this.lblWyborFigury.Name = "lblWyborFigury";
            this.lblWyborFigury.Size = new System.Drawing.Size(189, 34);
            this.lblWyborFigury.TabIndex = 2;
            this.lblWyborFigury.Text = "Zaznacz (kliknieciem myszą)\r\nfigury geometryczne do okazu)\r\n";
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblN.Location = new System.Drawing.Point(3, 107);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(200, 17);
            this.lblN.TabIndex = 3;
            this.lblN.Text = "Podaj liczbe figur do prezentacji ";
            // 
            // txtN
            // 
            this.txtN.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtN.Location = new System.Drawing.Point(21, 141);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(162, 29);
            this.txtN.TabIndex = 4;
            this.txtN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(39, 188);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(105, 57);
            this.btnStart.TabIndex = 5;
            this.btnStart.Text = "START";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // errorProvider2
            // 
            this.errorProvider2.ContainerControl = this;
            // 
            // lblGrubosc
            // 
            this.lblGrubosc.AutoSize = true;
            this.lblGrubosc.Location = new System.Drawing.Point(767, 473);
            this.lblGrubosc.Name = "lblGrubosc";
            this.lblGrubosc.Size = new System.Drawing.Size(94, 13);
            this.lblGrubosc.TabIndex = 8;
            this.lblGrubosc.Text = "Zmień grubość linii";
            // 
            // numericGrubosc
            // 
            this.numericGrubosc.Enabled = false;
            this.numericGrubosc.Location = new System.Drawing.Point(758, 489);
            this.numericGrubosc.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericGrubosc.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
            this.numericGrubosc.Name = "numericGrubosc";
            this.numericGrubosc.Size = new System.Drawing.Size(120, 20);
            this.numericGrubosc.TabIndex = 9;
            this.numericGrubosc.ValueChanged += new System.EventHandler(this.numericGrubosc_ValueChanged);
            // 
            // btnPrzesuniecieBezZmian
            // 
            this.btnPrzesuniecieBezZmian.Enabled = false;
            this.btnPrzesuniecieBezZmian.Location = new System.Drawing.Point(21, 251);
            this.btnPrzesuniecieBezZmian.Name = "btnPrzesuniecieBezZmian";
            this.btnPrzesuniecieBezZmian.Size = new System.Drawing.Size(159, 110);
            this.btnPrzesuniecieBezZmian.TabIndex = 10;
            this.btnPrzesuniecieBezZmian.Text = "Przesuniecie do nowego polozenia bez zmiany atrybutow graficznych";
            this.btnPrzesuniecieBezZmian.UseVisualStyleBackColor = true;
            this.btnPrzesuniecieBezZmian.Click += new System.EventHandler(this.btnPrzesuniecieBezZmian_Click);
            // 
            // btnZmienKolorTla
            // 
            this.btnZmienKolorTla.Location = new System.Drawing.Point(411, -7);
            this.btnZmienKolorTla.Name = "btnZmienKolorTla";
            this.btnZmienKolorTla.Size = new System.Drawing.Size(243, 42);
            this.btnZmienKolorTla.TabIndex = 11;
            this.btnZmienKolorTla.Text = "Zmien kolor tla powierzchni kreslarskiej";
            this.btnZmienKolorTla.UseVisualStyleBackColor = true;
            this.btnZmienKolorTla.Click += new System.EventHandler(this.btnZmienKolorTla_Click);
            // 
            // btnWziernikKoloruLinii
            // 
            this.btnWziernikKoloruLinii.Location = new System.Drawing.Point(411, 489);
            this.btnWziernikKoloruLinii.Name = "btnWziernikKoloruLinii";
            this.btnWziernikKoloruLinii.Size = new System.Drawing.Size(133, 33);
            this.btnWziernikKoloruLinii.TabIndex = 12;
            this.btnWziernikKoloruLinii.UseVisualStyleBackColor = true;
            this.btnWziernikKoloruLinii.Click += new System.EventHandler(this.btnWziernikKoloruLinii_Click);
            // 
            // btnZmienKolorLinii
            // 
            this.btnZmienKolorLinii.Enabled = false;
            this.btnZmienKolorLinii.Location = new System.Drawing.Point(222, 468);
            this.btnZmienKolorLinii.Name = "btnZmienKolorLinii";
            this.btnZmienKolorLinii.Size = new System.Drawing.Size(160, 54);
            this.btnZmienKolorLinii.TabIndex = 13;
            this.btnZmienKolorLinii.Text = "Zmien Kolor Linii";
            this.btnZmienKolorLinii.UseVisualStyleBackColor = true;
            this.btnZmienKolorLinii.Click += new System.EventHandler(this.btnZmienKolorLinii_Click);
            // 
            // lblWziernikKoloruLinii
            // 
            this.lblWziernikKoloruLinii.AutoSize = true;
            this.lblWziernikKoloruLinii.Location = new System.Drawing.Point(424, 473);
            this.lblWziernikKoloruLinii.Name = "lblWziernikKoloruLinii";
            this.lblWziernikKoloruLinii.Size = new System.Drawing.Size(97, 13);
            this.lblWziernikKoloruLinii.TabIndex = 14;
            this.lblWziernikKoloruLinii.Text = "Wziernik koloru linii";
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStop.Location = new System.Drawing.Point(39, 514);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(105, 57);
            this.btnStop.TabIndex = 15;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblZmienStylLinii
            // 
            this.lblZmienStylLinii.AutoSize = true;
            this.lblZmienStylLinii.Location = new System.Drawing.Point(603, 480);
            this.lblZmienStylLinii.Name = "lblZmienStylLinii";
            this.lblZmienStylLinii.Size = new System.Drawing.Size(83, 13);
            this.lblZmienStylLinii.TabIndex = 16;
            this.lblZmienStylLinii.Text = "Zmiana stylu linii";
            // 
            // comboBoxStylLinii
            // 
            this.comboBoxStylLinii.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStylLinii.Enabled = false;
            this.comboBoxStylLinii.FormattingEnabled = true;
            this.comboBoxStylLinii.Items.AddRange(new object[] {
            "Linia ciagla",
            "Linia przerywana (- - -)",
            "Linia przerywana kropkowana (. . .)",
            "Linia kropka linia (- . -)",
            "Linia kropka kropka (- . .)"});
            this.comboBoxStylLinii.Location = new System.Drawing.Point(555, 496);
            this.comboBoxStylLinii.Name = "comboBoxStylLinii";
            this.comboBoxStylLinii.Size = new System.Drawing.Size(197, 21);
            this.comboBoxStylLinii.TabIndex = 18;
            this.comboBoxStylLinii.SelectedIndexChanged += new System.EventHandler(this.comboBoxStylLinii_SelectedIndexChanged);
            // 
            // btnPrzesuniecieZeZmianami
            // 
            this.btnPrzesuniecieZeZmianami.Enabled = false;
            this.btnPrzesuniecieZeZmianami.Location = new System.Drawing.Point(21, 364);
            this.btnPrzesuniecieZeZmianami.Name = "btnPrzesuniecieZeZmianami";
            this.btnPrzesuniecieZeZmianami.Size = new System.Drawing.Size(159, 110);
            this.btnPrzesuniecieZeZmianami.TabIndex = 19;
            this.btnPrzesuniecieZeZmianami.Text = "Przesuniecie do nowego polozenia ze zmiana atrybutow graficznych";
            this.btnPrzesuniecieZeZmianami.UseVisualStyleBackColor = true;
            this.btnPrzesuniecieZeZmianami.Click += new System.EventHandler(this.btnPrzesuniecieZeZmianami_Click);
            // 
            // btnNowaFigura
            // 
            this.btnNowaFigura.Enabled = false;
            this.btnNowaFigura.Location = new System.Drawing.Point(21, 476);
            this.btnNowaFigura.Name = "btnNowaFigura";
            this.btnNowaFigura.Size = new System.Drawing.Size(159, 43);
            this.btnNowaFigura.TabIndex = 20;
            this.btnNowaFigura.Text = "Dodaj nowa figure geometryczna";
            this.btnNowaFigura.UseVisualStyleBackColor = true;
            this.btnNowaFigura.Click += new System.EventHandler(this.btnNowaFigura_Click);
            // 
            // lblNarzedzia
            // 
            this.lblNarzedzia.AutoSize = true;
            this.lblNarzedzia.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblNarzedzia.Location = new System.Drawing.Point(219, 452);
            this.lblNarzedzia.Name = "lblNarzedzia";
            this.lblNarzedzia.Size = new System.Drawing.Size(249, 21);
            this.lblNarzedzia.TabIndex = 21;
            this.lblNarzedzia.Text = "Wzierniki narzedzi graficznych:";
            // 
            // btnWlaczPrezentacje
            // 
            this.btnWlaczPrezentacje.Enabled = false;
            this.btnWlaczPrezentacje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWlaczPrezentacje.Location = new System.Drawing.Point(896, 318);
            this.btnWlaczPrezentacje.Name = "btnWlaczPrezentacje";
            this.btnWlaczPrezentacje.Size = new System.Drawing.Size(161, 87);
            this.btnWlaczPrezentacje.TabIndex = 22;
            this.btnWlaczPrezentacje.Text = "Wlacz prezentacje figur geometrycznych";
            this.btnWlaczPrezentacje.UseVisualStyleBackColor = true;
            this.btnWlaczPrezentacje.Click += new System.EventHandler(this.btnWlaczPrezentacje_Click);
            // 
            // txtIndeksFigury
            // 
            this.txtIndeksFigury.Enabled = false;
            this.txtIndeksFigury.Location = new System.Drawing.Point(923, 429);
            this.txtIndeksFigury.Name = "txtIndeksFigury";
            this.txtIndeksFigury.Size = new System.Drawing.Size(100, 20);
            this.txtIndeksFigury.TabIndex = 23;
            this.txtIndeksFigury.TextChanged += new System.EventHandler(this.txtIndeksFigury_TextChanged);
            // 
            // lblIndeksFigury
            // 
            this.lblIndeksFigury.AutoSize = true;
            this.lblIndeksFigury.Location = new System.Drawing.Point(920, 413);
            this.lblIndeksFigury.Name = "lblIndeksFigury";
            this.lblIndeksFigury.Size = new System.Drawing.Size(106, 13);
            this.lblIndeksFigury.TabIndex = 24;
            this.lblIndeksFigury.Text = "Indeks Figury (slajdu)";
            // 
            // btnPoprzedni
            // 
            this.btnPoprzedni.Enabled = false;
            this.btnPoprzedni.Location = new System.Drawing.Point(885, 455);
            this.btnPoprzedni.Name = "btnPoprzedni";
            this.btnPoprzedni.Size = new System.Drawing.Size(89, 23);
            this.btnPoprzedni.TabIndex = 25;
            this.btnPoprzedni.Text = "Poprzedni";
            this.btnPoprzedni.UseVisualStyleBackColor = true;
            this.btnPoprzedni.Click += new System.EventHandler(this.btnPoprzedni_Click);
            // 
            // btnNastepny
            // 
            this.btnNastepny.Enabled = false;
            this.btnNastepny.Location = new System.Drawing.Point(980, 455);
            this.btnNastepny.Name = "btnNastepny";
            this.btnNastepny.Size = new System.Drawing.Size(89, 23);
            this.btnNastepny.TabIndex = 26;
            this.btnNastepny.Text = "Nastepny";
            this.btnNastepny.UseVisualStyleBackColor = true;
            this.btnNastepny.Click += new System.EventHandler(this.btnNastepny_Click);
            // 
            // btnWylaczPrezentacje
            // 
            this.btnWylaczPrezentacje.Enabled = false;
            this.btnWylaczPrezentacje.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWylaczPrezentacje.Location = new System.Drawing.Point(877, 484);
            this.btnWylaczPrezentacje.Name = "btnWylaczPrezentacje";
            this.btnWylaczPrezentacje.Size = new System.Drawing.Size(192, 54);
            this.btnWylaczPrezentacje.TabIndex = 27;
            this.btnWylaczPrezentacje.Text = "Wylacz prezentacje figur geometrycznych";
            this.btnWylaczPrezentacje.UseVisualStyleBackColor = true;
            this.btnWylaczPrezentacje.Click += new System.EventHandler(this.btnWylaczPrezentacje_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tag = "0";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBarX
            // 
            this.trackBarX.Enabled = false;
            this.trackBarX.Location = new System.Drawing.Point(341, 540);
            this.trackBarX.Maximum = 500;
            this.trackBarX.Name = "trackBarX";
            this.trackBarX.Size = new System.Drawing.Size(104, 45);
            this.trackBarX.TabIndex = 28;
            this.trackBarX.Scroll += new System.EventHandler(this.trackBarX_Scroll);
            // 
            // txtX
            // 
            this.txtX.Location = new System.Drawing.Point(464, 540);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(57, 20);
            this.txtX.TabIndex = 29;
            // 
            // trackBarY
            // 
            this.trackBarY.Enabled = false;
            this.trackBarY.Location = new System.Drawing.Point(555, 540);
            this.trackBarY.Maximum = 500;
            this.trackBarY.Name = "trackBarY";
            this.trackBarY.Size = new System.Drawing.Size(104, 45);
            this.trackBarY.TabIndex = 30;
            this.trackBarY.Scroll += new System.EventHandler(this.trackBarY_Scroll);
            // 
            // txtY
            // 
            this.txtY.Location = new System.Drawing.Point(677, 540);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(57, 20);
            this.txtY.TabIndex = 31;
            // 
            // lblUstawNoweWspolrzedne
            // 
            this.lblUstawNoweWspolrzedne.AutoSize = true;
            this.lblUstawNoweWspolrzedne.Location = new System.Drawing.Point(150, 525);
            this.lblUstawNoweWspolrzedne.Name = "lblUstawNoweWspolrzedne";
            this.lblUstawNoweWspolrzedne.Size = new System.Drawing.Size(281, 13);
            this.lblUstawNoweWspolrzedne.TabIndex = 32;
            this.lblUstawNoweWspolrzedne.Text = "Ustaw nowe wspolrzedne (polozenia figury geometrycznej)";
            // 
            // lblX
            // 
            this.lblX.AutoSize = true;
            this.lblX.Location = new System.Drawing.Point(441, 543);
            this.lblX.Name = "lblX";
            this.lblX.Size = new System.Drawing.Size(17, 13);
            this.lblX.TabIndex = 33;
            this.lblX.Text = "X:";
            // 
            // lblY
            // 
            this.lblY.AutoSize = true;
            this.lblY.Location = new System.Drawing.Point(654, 543);
            this.lblY.Name = "lblY";
            this.lblY.Size = new System.Drawing.Size(17, 13);
            this.lblY.TabIndex = 34;
            this.lblY.Text = "Y:";
            // 
            // btnPrzesunLosowoBezZmian
            // 
            this.btnPrzesunLosowoBezZmian.Enabled = false;
            this.btnPrzesunLosowoBezZmian.Location = new System.Drawing.Point(21, -3);
            this.btnPrzesunLosowoBezZmian.Name = "btnPrzesunLosowoBezZmian";
            this.btnPrzesunLosowoBezZmian.Size = new System.Drawing.Size(159, 107);
            this.btnPrzesunLosowoBezZmian.TabIndex = 35;
            this.btnPrzesunLosowoBezZmian.Text = "Przesun do losowo wybranej lokalizacji bez zmian atrybutow graficznych";
            this.btnPrzesunLosowoBezZmian.UseVisualStyleBackColor = true;
            this.btnPrzesunLosowoBezZmian.Click += new System.EventHandler(this.btnPrzesunLosowoBezZmian_Click);
            // 
            // btnPrzesunLosowoZeZmianami
            // 
            this.btnPrzesunLosowoZeZmianami.Enabled = false;
            this.btnPrzesunLosowoZeZmianami.Location = new System.Drawing.Point(896, 17);
            this.btnPrzesunLosowoZeZmianami.Name = "btnPrzesunLosowoZeZmianami";
            this.btnPrzesunLosowoZeZmianami.Size = new System.Drawing.Size(159, 107);
            this.btnPrzesunLosowoZeZmianami.TabIndex = 36;
            this.btnPrzesunLosowoZeZmianami.Text = "Przesun do losowo wybranej lokalizacji z losowa zmiana atrybutow graficznych";
            this.btnPrzesunLosowoZeZmianami.UseVisualStyleBackColor = true;
            this.btnPrzesunLosowoZeZmianami.Click += new System.EventHandler(this.btnPrzesunLosowoZeZmianami_Click);
            // 
            // btnPowrot
            // 
            this.btnPowrot.Location = new System.Drawing.Point(187, -3);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(152, 53);
            this.btnPowrot.TabIndex = 37;
            this.btnPowrot.Text = "Powrot do formularza glownego";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click);
            // 
            // LaboratoriumNr2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 631);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.btnPrzesunLosowoZeZmianami);
            this.Controls.Add(this.btnPrzesunLosowoBezZmian);
            this.Controls.Add(this.lblY);
            this.Controls.Add(this.lblX);
            this.Controls.Add(this.lblUstawNoweWspolrzedne);
            this.Controls.Add(this.txtY);
            this.Controls.Add(this.trackBarY);
            this.Controls.Add(this.txtX);
            this.Controls.Add(this.trackBarX);
            this.Controls.Add(this.btnWylaczPrezentacje);
            this.Controls.Add(this.btnNastepny);
            this.Controls.Add(this.btnPoprzedni);
            this.Controls.Add(this.lblIndeksFigury);
            this.Controls.Add(this.txtIndeksFigury);
            this.Controls.Add(this.btnWlaczPrezentacje);
            this.Controls.Add(this.lblNarzedzia);
            this.Controls.Add(this.btnNowaFigura);
            this.Controls.Add(this.btnPrzesuniecieZeZmianami);
            this.Controls.Add(this.comboBoxStylLinii);
            this.Controls.Add(this.lblZmienStylLinii);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.lblWziernikKoloruLinii);
            this.Controls.Add(this.btnZmienKolorLinii);
            this.Controls.Add(this.btnWziernikKoloruLinii);
            this.Controls.Add(this.btnZmienKolorTla);
            this.Controls.Add(this.btnPrzesuniecieBezZmian);
            this.Controls.Add(this.numericGrubosc);
            this.Controls.Add(this.lblGrubosc);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.lblWyborFigury);
            this.Controls.Add(this.chbFiguryGeometryczne);
            this.Controls.Add(this.pbRysownica);
            this.Name = "LaboratoriumNr2";
            this.Text = "LaboratoriumNr2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LaboratoriumNr2_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericGrubosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.CheckedListBox chbFiguryGeometryczne;
        private System.Windows.Forms.Label lblWyborFigury;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ErrorProvider errorProvider2;
        private System.Windows.Forms.NumericUpDown numericGrubosc;
        private System.Windows.Forms.Label lblGrubosc;
        private System.Windows.Forms.Button btnPrzesuniecieBezZmian;
        private System.Windows.Forms.Button btnZmienKolorTla;
        private System.Windows.Forms.Button btnWziernikKoloruLinii;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnZmienKolorLinii;
        private System.Windows.Forms.Label lblWziernikKoloruLinii;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblZmienStylLinii;
        private System.Windows.Forms.ComboBox comboBoxStylLinii;
        private System.Windows.Forms.Button btnPrzesuniecieZeZmianami;
        private System.Windows.Forms.Button btnNowaFigura;
        private System.Windows.Forms.Label lblNarzedzia;
        private System.Windows.Forms.Button btnWlaczPrezentacje;
        private System.Windows.Forms.Label lblIndeksFigury;
        private System.Windows.Forms.TextBox txtIndeksFigury;
        private System.Windows.Forms.Button btnNastepny;
        private System.Windows.Forms.Button btnPoprzedni;
        private System.Windows.Forms.Button btnWylaczPrezentacje;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar trackBarX;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TrackBar trackBarY;
        private System.Windows.Forms.Label lblY;
        private System.Windows.Forms.Label lblX;
        private System.Windows.Forms.Label lblUstawNoweWspolrzedne;
        private System.Windows.Forms.Button btnPrzesunLosowoZeZmianami;
        private System.Windows.Forms.Button btnPrzesunLosowoBezZmian;
        private System.Windows.Forms.Button btnPowrot;
    }
}