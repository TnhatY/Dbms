   M S B A M L   `   `   `  ����@  <Do_an, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Do_anDo_an  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5      "    Do_an.UC_DoanhThuLoaiSanPham   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Do_an     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        � 	Resources  5
      "  LiveCharts.Wpf.DefaultLegend �� 
TargetType �� Property �� Value   FocusVisual �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 ButtonStyle1 �� 
TargetType ��Name	 �� CornerRadius
 ��Name �� Triggers P� Property P� Value �� 
TargetName��%1  '        &	  �     &	 G    &	 j    &	 �    &	 �    &	 �    &	 �    &	     &	 <    &		 _    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5   
   "  6   .�5      ��  � ��
 �   �6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ 14(�6)   5      �� 5   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   #��� ��6E   $
 true��6�   $��1��6�   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5    
   $ 	#FFADB2B5��69   �� 5!   
   $ 	#FF838383��6=   �� 5"   
   " ��6%   .�5#      ��  �@�FocusVisualStyle8   61   �� 5$       � ��8  6+   �� 5%       � ��8  6,   �� 5&       � ��# � ��6+   �� 5'       � ��$ 1q�60   �� 5(       � ��$ Center=�6;   �� 5)       � ��$ Center=�69   �� 5*       � ��$ 1q�6(   �� 5+       � �� 5,      �� 5-      " ��6&   .R�5.      �� $ border��6!   $	 5��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5/      �� $
 contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  50       51      P� 52       �@��IsDefaulted$
 true��6=   . �53   "   �� $ border��6@   # � ��6T    � ��54      P� 55       �@J�IsMouseOver$
 true��6=   . �56   "   �� $ border��6?   8   � ��6S   �� 57   "   $ border��6@   8   � ��6T   58      P� 59       � ��$
 true��6;   . �5:   "   �� $ border��6?   8   � ��6S   �� 5;   "   $ border��6@   8   � ��6T   5<      P� 5=       � {�$ false��6;   . �5>   "   �� $ border��6?   8   � ��6S   �� 5?   "   $ border��6@   8   � ��6T   �� 5@   "   $ contentPresenter��6K   8 	  � ��6i   5A      5C      5E      5F      5G      .��5H      � ���	#FFE2C7E6$��0,0,-98,-201q�6"   .+�5I   
   �� -   5         ��Name$ cb_thang��5I      $
��Left=�6%   $��
273,74,0,0q�6@   $	��Top=�6T   $	��108��6l   $��24��6x   �� 5J   
   -   5        $ cb_nam��5J      $
��Left=�6#   $��
413,74,0,0q�6>   $	��Top=�6R   $��68��6j   $��24��6u   �� 5K   
   -   5        #��� 
 5K      $��Xem Doanh Thu��68   $
��Left=�6P   $��
520,56,0,0q�6k   $	��Top=�6   ���	#FFFFAEAE$��40��6�   $	��100��6�   � 5L   
   $	��406��6   $	��Top=�6   $��44,140,106,0q�64   .+�5N      #  LiveCharts.Wpf.CartesianChart  -   5          Name$ RevenueChart��5N   !   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$ Right=�67   $��10,-27,64,0q�6N   ���	#FFF3F4F85P      5Q      �� 5R   
   -   5         ��Name$ lblChonThang��5R      $��Chọn tháng��6'   $
��Left=�6<   $��
273,43,0,0q�6W   $	��Top=�6k   �� 5S   
   -   5        $ 
lblChonNam��5S      $��Chọn năm��6%   $
��Left=�68   $��
413,43,0,0q�6S   $	��Top=�6g   5T      5U      