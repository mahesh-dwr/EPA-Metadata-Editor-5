﻿/*
COPYRIGHT 1995-2009 ESRI
TRADE SECRETS: ESRI PROPRIETARY AND CONFIDENTIAL
Unpublished material - all rights reserved under the 
Copyright Laws of the United States.
For additional information, contact:
Environmental Systems Research Institute, Inc.
Attn: Contracts Dept
380 New York Street
Redlands, California, USA 92373
email: contracts@esri.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ESRI.ArcGIS.Metadata.Editor;
using ESRI.ArcGIS.Metadata.Editor.Pages;
namespace EPAMetadataEditor.Pages
{
    /// <summary>
    /// Interaction logic for MD_LegalConstraintsSOR.xaml
    /// </summary>
    public partial class MD_LegalConstraintsSOR : EditorPage
    {
        public MD_LegalConstraintsSOR()
        {
            InitializeComponent();
        }

        public List<Control> AllChildren(DependencyObject parent)
        {
            var _List = new List<Control> { };
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
            {
                var _Child = VisualTreeHelper.GetChild(parent, i);
                if (_Child is Control)
                    _List.Add(_Child as Control);
                _List.AddRange(AllChildren(_Child));
            }
            return _List;
        }

        private void cboSystemNames_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //ListBox liBox = (ListBox)lbxLegalConstsOtherLimits;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    string liBoxName = "tbxLegalConstsSystemURL";
            //    TextBox tbxLegalURL = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    tbxLegalURL.Focus();
            //}
        }

        private void cboSystemNames_LostFocus(object sender, RoutedEventArgs e)
        {
            //ListBox liBox = (ListBox)lbxLegalConstsOtherLimits;
            //foreach (var liBoxItem in liBox.Items)
            //{
            //    var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
            //    var liBoxChildren = AllChildren(liBoxCont);
            //    string liBoxName = "tbxLegalConstsSystemURL";
            //    TextBox tbxLegalURL = (TextBox)liBoxChildren.First(c => c.Name == liBoxName);
            //    string liBoxName2 = "cboSystemNames";
            //    ComboBox cboSysURL = (ComboBox)liBoxChildren.First(c => c.Name == liBoxName2);
            //    tbxLegalURL.Text = cboSysURL.Text;
            //    tbxLegalURL.Focus();
            //}
        }

        private void cboSystemNames_LostMouseCapture(object sender, MouseEventArgs e)
        {
            ListBox liBox = (ListBox)lbxLegalConstsOtherLimits;
            string testURL = "";
            foreach (var liBoxItem in liBox.Items)
            {
                var liBoxCont = liBox.ItemContainerGenerator.ContainerFromItem(liBoxItem);
                var liBoxChildren = AllChildren(liBoxCont);
                string tbxName = "tbxLegalConstsSystemURL";
                TextBox tbxLegalURL = (TextBox)liBoxChildren.First(c => c.Name == tbxName);
                string cboBoxName = "cboSystemNames";
                ComboBox cboSysName = (ComboBox)liBoxChildren.First(c => c.Name == cboBoxName);
                System.Xml.XmlElement xmlTest = (System.Xml.XmlElement)cboSysName.SelectedItem;
                tbxLegalURL.Text = cboSysName.Text;
                if (cboSysName.SelectedValue != null)
                {
                    testURL = xmlTest.LastChild.InnerText;
                    tbxLegalURL.Text = testURL;
                }
                tbxLegalURL.Focus();
            }
        }
    }
}
