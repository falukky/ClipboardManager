   M S B A M L   `   `   `  ����K  GClipboardManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ClipboardManagerClipboardManager  5   	   W0clr-namespace:ClipboardManager.Classes.Behaviors"ClipboardManager.Classes.Behaviors  5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity 5	   	   !    ClipboardManager.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   *localclr-namespace:ClipboardManager  5   	   @	behaviors0clr-namespace:ClipboardManager.Classes.Behaviors  5   	   XiPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity  5	   	   -   5          � WindowStyle$
  None=�5   	    � 
ResizeMode$ CanResizeWithGrip=�5   	    � AllowsTransparency .  � WindowStartupLocation$ CenterScreen=�5   	   
������  � Title$ Clipboard Manager��5   	   $	��600��5   	   $	��500��5   	   $	��600��5   	   $	��500��5   	   .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ Closing��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *WindowCloseCommad+5      	 � 	Resources	 5!      ��%    5+      .��5-      �� 
 �� CornerRadius$
 5��6   ���	#FF1F508B$��1,1,1,1q�66   
�������._�5.   
   �  � RowDefinitions 5/      �� 50      $��40 �6    �� 51      $��* �6    �� 52      $��40 �6    .+�54      �� -   5        $��0��54      $
 5,5,0,0��6"   ���	#FF1F508B
�������$��	0,0,0,0.5q�6e   ._�55      �  � ColumnDefinitions 56      �� 57      $��10 �6+   �� 58      $��* �6+   �� 59      $��* �6+   .+�5;      ��  �� Orientation$ 
Horizontal=�6!   $��1��6:   .+�5<      �� $��22��6    $��22��5=       $3��-pack://application:,,,/Resources/app_icon.ico��5>       �� 5?      $��Clipboard Manager��6$   
�������$��Center=�5A       $��18(�5B       $
��Bold"�5C       $��5,0,0,0q�5D   $   5E      � 5F      $��2��6   $��Center=�6+   $��Right=�6F   .+�5G      �� $ 
Horizontal=�6%   .+�5H      �� -   5        $��btnSettings��5H   %   $��40��5I   %   $��40��5J   %   $��0q�5K   %    � ToolTip$ Settings��5L   %   ��5N   "   �� 5O   &    �� 
TargetType" ��6,    �� Triggers 5P   *   P� 5Q   .    P� Property �@J�IsMouseOver P� Value .  . �5R   2   ��  �� Property � �� �� Value
 ���� 6O   �� 5S   2    � ��
 �����6O   5T   /   P� 5V   .    �@J�IsMouseOver . . �5W   2   ��  � �� 5X   :   �� 5Y   >    �� Color$ Silver��6N    �� Opacity$ .2Q�6]   5[   7   �� 5\   2    � ��
 �����6O   5]   /   .�5_   *   ��  � �� 5`   .   �� 5a   2    �� 
TargetType" ��6B   .R�5b   6   ��  ��Name$ Border��5c   ,   #��z��5b   =   $
 5��5d   ,   
������ #��z��5f   ,   $��1q�5g   ,   '  !System.Windows.VisualStateManager   VisualStateGroups 5h   :   %  System.Windows.VisualStateGroup  5i   >   CommonStates��   Transitions 5j   B   %  System.Windows.VisualTransition  5k   F      GeneratedDuration$ 0:0:0.5D�6W     5l   F   $ 0D�6W   	   To$ Pressed��6m      States. 5n   B      System.Windows.VisualState  
Normal��6N     5o   B   	MouseOver��6N     5p   B   
MouseLeave��6N     5q   B   Pressed��6N     5r   B   Disabled��6N   5s   ?   ._�5u   :   �� $��2q�6K   $��Center=�5v   F   $��Center=�5w   7   ��. 5x   7   5y   7   5z   3   5|   +   5}   '   .��5   "   '	  !MaterialDesignThemes.Wpf.PackIcon	  �
  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]] 
  Kind$ Settings=�6:   $��20��5�   6   $��20��5�   6   5�      �� 5�      -   5        $��btnMinimize��5�   %   $��40��5�   !   $��40��5�   !   $��0q�5�   !   $ Minimize��5�   !   ��5�   "   �� 5�   &   " ��6,    5�   *   P� 5�   .    �@J�IsMouseOver .  . �5�   2   ��  � ��
 ���� 6O   �� 5�   2    � ��
 �����6O   5�   /   P� 5�   .    �@J�IsMouseOver . . �5�   2   ��  � ��
 �<��6O   �� 5�   2    � ��
 �����6O   5�   /   .�5�   *   ��  � �� 5�   .   �� 5�   2   " ��6B   .R�5�   6   �� $ Border��5�   ,   #��z��5�   =   $
 5��5�   ,   
������ #��z��5�   ,   $��1q�5�   ,    5�   :     5�   >   CommonStates�� 5�   B     5�   F   $ 0:0:0.5D�6W     5�   F   $ 0D�6W   $ Pressed��6m   . 5�   B     
Normal��6N     5�   B   	MouseOver��6N     5�   B   
MouseLeave��6N     5�   B   Pressed��6N     5�   B   Disabled��6N   5�   ?   ._�5�   :   �� $��2q�6K   $��Center=�5�   F   $��Center=�5�   7   ��. 5�   7   5�   7   5�   3   5�   +   5�   '   .��5�   "   	  $ WindowClose=�6:   $��22��5�   6   $��22��5�   6   5�      5�      5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $��20 �6'   �� 5�      $��* �6'   �� 5�      $��20 �6'   .+�5�      � $��1��6    5�      �� 5�      $��15 �6(   �� 5�      $��* �6(   �� 5�      $��15 �6(   .+�5�      �� -   5        $��ListViewUsers��5�      $��1��5�      
������ 
������ $��0,0,0,0q�5�      *  $MaterialDesignThemes.Wpf.ThemeAssist   Theme$
 Dark=�5�         ListViewItemStyle#��[  5�      $��Disabled=�5�      $
��Auto=�5�        �� SelectionMode$  Single=�5�      $��0,0,0,0q�5�      ! � FocusVisualStyle! 5�      Z� ��5�      �� *
Clipboards+" �� View" 5�      �� 5�       & "GridViewColumnHeaderCollapsedStyle!# �� ColumnHeaderContainerStyle## [ 6'   .P�5�   "   �� $ �� Width$
$ 1000��61   % �� CellTemplate% 5�   &   �� 5�   *   .R�5�   .   � .+�5�   2   �  5�   6   �� 5�   :   $
��Auto �6K   �� 5�   :   $
��Auto �6K   .+�5�   6   �� $��16��6<   $��16��5�   <   $��0��5�   <   ��5�   <   �� & �� Path$& Index� & "ClipboardItemIndexToImageConverter' �� 	Converter#' [ 5�   <   �� 5�   6   $��1��5�   @   $��5,0,0,0q�5�   @   ��5�   @   �� $
& Text���5�   @   �� $& 
Foreground�( �� RelativeSource( �� ) �� Mode$) FindAncestor=�* �� AncestorType"* �� 5�   :   _� 5�   >   + ^� ShowDuration$
+ 5000��6F   , _� 	Placement$
, Left=�5�   F   - _� PlacementRectangle$- 0,0,0,0�5�   F   . _� HorizontalOffset$	. -45��5�   F   / _� VerticalOffset$	/ -10��5�   F   0 _� HasDropShadow0 .  ��5�   B   �� 5�   F   $ Vertical=�6Q   .+�5�   J   �� ��6R   �� $
& Time��� 5�   J   ��6R   �� $
& Text�5�   G   5�   ?   5�   7   5�   3   5   /   5  +   .��5  C   `5  #   5     5     5     � 5     $��2��6   5
     5     �� 5     $��2��6   $
 0,0,0,0��6"   
�������$��	0,0.5,0,0q�6N   5     5     5     5     