   M S B A M L   `   `   `  ����@  <Do_an, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Do_anDo_an  5          Do_an.UC_HoaDon   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Do_an     5      -   5          � 	Resources  5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
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
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      � ���	#FFE0CDED.+�5E   
   �� $��Hoá đơn từ��6   $��10 15q�6&   $
��Bold"�65   $��13(�6G   6W   (  "System.Windows.Controls.DatePicker  5F   
   -   5        $��
ngaybatdau��5F      $��16(�6M   $	��150��6[   $��25��6g   $	��Top=�6s   $
��left=�6�   $��85 10q�6�      SelectedDate 6'   �� *SelectedDate+6�   �� 5H   
   $��đến��6   $��250 15q�6   $
��Bold"�6/   $��13(�6A   6Q     5I   
   -   5        $��ngayketthuc��5I      $��16(�6N   $	��150��6\   $��25��6h   $	��Top=�6t   $
��left=�6�   $��280 10q�6�    6(   �� *SelectedDate+6�   �� 5J   
   -   5         ��Name$ 
btnTimkiem��5J   8   #��� 
 6   $��25��6L   $	��100��6X   $��Tìm kiếm��6d   $	��Top=�6w   $
��Left=�6�   $��
450 10 0 0q�6�   ���	#FF8BBBBB���	#FF8BBBBB6  &   System.Windows.Controls.DataGrid  5K   
   -   5          Name$ dgHoaDon��5K      
������ $��10 50 10 10q�6>      AutoGenerateColumns$ False��6S      	RowHeight$ 40Q�6o      GridLinesVisibility$
 None=�6~      Columns 5L      0  *System.Windows.Controls.DataGridTextColumn  5M      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã HĐ��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 100 6M   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *MaHD+6M     5N      $ Ngày xuất HĐ��6%   $	 150 6y    6;   �� *
NgayXuatHD+ �� StringFormat$ {0:dd/MM/yyyy}��6y     5O      $ Tên sản phẩm��6%   $	 150 6U    6;   �� *TenSP+6U     5P      $ Trị giá HĐ��6%   $	 150 6V    69   �� *
TriGiaHD+6V     5Q      $ Tên khách hàng��6%   $	 200 6^    6=   �� *TenKhachHang+6^     5R      $ SĐT khách hàng��6%   $	 150 6f    6=   �� *SoDienThoaiKhachHang+6f     5S      $ Nhân viên tạo HĐ��6%   $	 150 6_    6?   �� *TenNhanVien+6_   5V      5X      5Y      