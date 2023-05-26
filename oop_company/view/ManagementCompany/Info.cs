﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ManagementCompany
{
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            text();

            okButton.DialogResult = DialogResult.OK;
            this.AcceptButton = okButton;
        }

        private void text()
        {
            textLabel.Text = "\tЗдесь расписана общая информация\n" +
                "\n1. При загрузке из файла: вся информация передается в объект класса HouseList, " +
                "изначально в dataGrid выводится только столбец с улицами. Чтобы увидеть подробную информацию, " +
                "нужно нажать на название улицы. Тогда выведется информация в других двух таблицах обо всех домах " +
                "на этой улице и всех квартирах в данном доме (при нажатии на определенный дом)." +
                "\n2. В таблице по центру есть столбец \"Всего квартир\". Туда заносится информация о количестве квартир " +
                "в доме. Правее - текущее количество внесенных квартир. Кроме того нельзя ввести номер квартиры, выходящий " +
                "за пределы количества квартир в доме." +
                "\n3. Удаление дома согласно очереди без заголовка, удаляется первый внесенный объект." +
                "\n4. Удаление квартиры согласно упорядоченному списку. Возможно удаление квартиры, независимо от ее позиции." +
                "\n5. Квартиры упорядочены. При добавлении всегда происходит сортировка.";
        }
    }
}
