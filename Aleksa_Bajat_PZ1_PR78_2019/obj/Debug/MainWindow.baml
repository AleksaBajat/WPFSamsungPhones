   M S B A M L   `   `   `  ����U  QAleksa_Bajat_PZ1_PR78_2019, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:Aleksa_Bajat_PZ1_PR78_2019Aleksa_Bajat_PZ1_PR78_2019  5   	   +    %Aleksa_Bajat_PZ1_PR78_2019.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:Aleksa_Bajat_PZ1_PR78_2019     5   	   -   5          � Title$  Samsung Phones��5   	    � WindowStyle$
 None=�6     � AllowsTransparency . 
������ $	��866��6�   .��5	      �� $	��400��6   $	��800��6   .+�5
   
   F� -   5        $��UIPath��5
   1   
�������$��1��6   ��5      �� 5       �� Color$ 
GhostWhite��6"   67   ��5      B� 5      .��5      E�  E� 
StartPoint$
 50,0&�6!   .��5      ��  �� Size$ 40,100��6%    �� RotationAngle$	 180Q�63    �� 
IsLargeArc .  �� Point$ 50,400&�6Y   6j   �� 5      	 �� Point$	 750,400&�6&   68   �� 5      $ 40,100��6%   $	 180Q�63   
 �� SweepDirection$
 Counterclockwise=�6G    . $ 750,0&�6{   6�   �� 5      $
	 50,0&�6&   65   5      5      5      &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGrid��5      $	��240��6#    �� Left$ 41��60   
 �� Top$	 138��6A   $	��724��6R      AutoGenerateColumns .     
IsReadOnly .    CanUserResizeColumns .     CanUserAddRows .     CanUserDeleteRows .     CanUserReorderColumns .     CanUserResizeRows .  ��6^   �� *	PhoneList+   Columns 5      4  .System.Windows.Controls.DataGridTemplateColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Image��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 68      CellTemplate 5       �� 5!      .R�5"      �� $	��img��6$   $��80��6/   $��80��6;   ��6F   �� *PathToImage+5#      5%      0  *System.Windows.Controls.DataGridTextColumn  5&      $ * 6%   $ 
Phone Name��6/   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6C   �� *	PhoneName+6c     5'      $ * 6%   $ Android Version��6/    6H   �� *AndroidVersion+6m     5(      $ * 6%   $ Date of Release��6/    6H   �� *ReleaseDate+6j     5)      $ Options��6)   $ * 6:    5*      �� 5+      .R�5,      �� $��Center=�6)    �� Orientation$ Vertical=�6D   .+�5-   "   �� $��Details��6)   -   5        $	��0,2q�5-   8   $��Details��6[   �� 5.   "   $
��Edit��6)   -   5        $	��0,2q�5.   5   $
��Edit��6U   �� 5/   "   $��Delete��6)   -   5        $	��0,2q�5/   7   $��Delete��6Y   50      51      53      55      ]� 58   
   $��22��6   ��.  $ 50��66   $ 0��6G   $	��706��6V   .+�59      �� -   5        $��ButtonClose��59      $��X��6(   $��22��64   $	��Top=�6@   $��43��6X   $��0q�6c   $��Right=�6w   6�   �� 5:      $��Samsung Phones��6   $��32��6-   $	��Top=�69   $��	0,0,0,-10q�6Q   5;      �� 5<   
   -   5        $��AddNewButton��5<      $��Add New Phone��6%   $��40(�6=   $ 50��6K   $ 43��6\   $	��706��6l   $��76��6x   
�������6�   5@      5A      