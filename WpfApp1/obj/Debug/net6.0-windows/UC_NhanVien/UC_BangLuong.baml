   M S B A M L   `   `   `  ����@  <Do_an, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Do_anDo_an  5          Do_an.UC_BangLuong   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Do_an     5      -   5          � 	Resources  5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6%   .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      " ��6&   .R�5(      �� $ border��6!   $	 4��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5)      �� $
 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5C      � ���	#FFE0CDED.+�5E   
   ��  �� Orientation$ 
Horizontal=�6   $��10q�6.   $��Right=�6:   .+�5F      �� $��Tháng:��6   $	��Top=�6&   $��0,8,5,0q�6>   �� 5G      -   5         ��Name$ cbThang��5G      $��60��6(    �� SelectedIndex$ 0��63   $��25��6E   $	��Top=�6Q   $��0 5 0 0q�6i   .@�5H      �� $��1��6   �� 5I      $��2��6   �� 5J      $��3��6   �� 5K      $��4��6   �� 5L      $��5��6   �� 5M      $��6��6   �� 5N      $��7��6   �� 5O      $��8��6   �� 5P      $��9��6   �� 5Q      $��10��6   �� 5R      $��11��6   �� 5S      $��12��6   5T      �� 5V      $��Năm:��6   $��25��6$   $	��top=�60   $��10 8 0 0q�6H   6\   �� 5W      -   5        $ cbNam��5W      $��80��6&   $��25��61   $	��Top=�6=   $��10 5 0 0q�6U   $ 0��6g   .@�5X      �� $
��2023��6   �� 5Y      $
��2024��6   �� 5Z      $
��2025��6   5[      �� 5]      -   5         ��Name$ btnLuong��5]   U   #��� 
 6   
������ $��25��6h   $	��Top=�6t   $��	20 5 50 0q�6�   $	��100��6�   ���	#FFC20BDF.��5^      �� $��Tính lương��6   60   5_      5`      &   System.Windows.Controls.DataGrid  5c   
   -   5          Name$ dataGridBangLuong��5c         AutoGenerateColumns$ False��6/   $��10,50,10,10q�6K      
IsReadOnly$
 True��6`      GridLinesVisibility$
 None=�6r      	RowHeight$ 40Q�6�      Columns 5d      0  *System.Windows.Controls.DataGridTextColumn  5e      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã NV��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 80 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *MaNV+6M     5f      $
 Họ��6%   $	 100 6J    61   �� *HoNV+6J     5g      $
 Tên��6%   $	 150 6L    62   �� *TenNV+6L     5h      $ Tên Công Việc��6%   $	 200 6V    6<   �� *TenCV+6V     5i      $ Lương Theo Giờ��6%   $	 150 6h    6=   �� *Luong+ �� StringFormat$ C��6h     5j      $ Số Ca��6%   $	 100 6M    64   �� *SoCa+6M     5k      $ Số Giờ Làm��6%   $	 100 6W    69   �� *	TongSoGio+6W     5l      $ Tổng Lương��6%   $	 150 6g    69   �� *	TongLuong+$ C��6g   5n      5o      5p      