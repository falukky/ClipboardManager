   M S B A M L   `   `   `  ����K  GClipboardManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ClipboardManager.stylesClipboardManager.styles  5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089   ScrollThumbs  �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� CornerRadius �� Color �� Opacity	 �� Triggers
 P� Property P� Value �� 
TargetName � RowDefinitions ]�Name ]� Thumb n�Name ]� IncreaseRepeatButton ��Name J� Opacity ]� DecreaseRepeatButton P� 
SourceName  ButtonSelectBrush  	DarkBrush �� Angle�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      /local%clr-namespace:ClipboardManager.styles  5      %7	  &	        '�� ~    �� 5      "  n�6!   .�5   
   ��  � �� 5      �� 5	      " n�6"   .R�5
      � $
 Grid��6   .+�5      �� $��Stretch=�6$   $��Stretch=�6B   $
��Auto��6^   $
��Auto��6k   
������ 6y   �� 5      $ 
Rectangle1��6!   $ 5��65   $��Stretch=�6F   $��Stretch=�6d   $
��Auto��6�   $
��Auto��6�   ��5      �� 5   "   $ 	#FF1F508B��62   $ .4Q�6D   5      5      	 5      P� 5      
 �@�Tag$ 
Horizontal��61   . �5      �� $ 
Rectangle1��6%    � ��$
 Auto��6N   �� 5      $ 
Rectangle1��6%    � ��$ 7��6O   5      5      5      5      �� 5      "  ��6'   .�5   
   ��  �@��IsFlicksEnabled .  63   �� 5   
    � �� �#8C8C8C6'   �� 5    
    � ��
 ���� 6'   �� 5!   
    � ��$ 8��6"   �� 5"   
    � �� 5#      �� 5$      " ��6"   .R�5%      � $ GridRoot��6   $��8��6-   #��z��67    5&      �� 5'      $��0.00001* �6,   .+�5)      ]� $ 
PART_Track��6    $��0��64   ��. |�.   5*      n� 5+   "   $ Thumb��6(   #��z��67   #���   6a    5-      �� 5.   "   $ PageUp��6/   $��ScrollBar.PageDownCommand��6?   $ 0Q�6c   |�.  6o    50      �� 51   "   $ PageDown��6/   $��ScrollBar.PageUpCommand��6A   $ 0Q�6c   |�.  6o   53      54      	 55      P� 56      $ Thumb��6"   
 �@J�IsMouseOver . . �57      �� # �  6%   $ Thumb��6Q    � ��6d   58      P� 59      $ Thumb��6"   
 �@n�
IsDragging . . �5:      �� # �  6%   $ Thumb��6I    � ��6\   5;      P� 5<      
 � {� .  . �5=      �� $ Thumb��6%    � y�$ 	Collapsed=�6N   5>      P� 5?      
 �@��Orientation$ 
Horizontal=�69   . �5@      �� $ GridRoot��6%    �@�LayoutTransform 5A   "   �� 5B   &   $	 -90Q�66   5D      �� 5E      $ 
PART_Track��6%    �@�LayoutTransform 5F   "   �� 5G   &   $	 -90Q�66   5I      �� 5J       � ��$
 Auto��66   �� 5K       � ��$ 8��67   �� 5L      $ Thumb��6%    �@�Tag$ 
Horizontal��6G   �� 5M      $ PageDown��6%    � ��$ ScrollBar.PageLeftCommand��6N   �� 5N      $ PageUp��6%    � ��$  ScrollBar.PageRightCommand��6L   5O      5Q      5S      5T      5U      