   M S B A M L   `   `   `  ����@  <ITLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ITLab.View
ITLab.View  5          ITLab.View.MessageView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:ITLab.View     5      $
��auto��5      .��5	      ��   �� CornerRadius$  10��6    �� Padding$ 5q�6   
�������$
��auto��6>   $��Center=�6L   $��0,0,-0.4,0.4q�6i   $	��602��6    J� Effect 5
   
   3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 20Q�6      ShadowDepth$ 0Q�6/      Opacity$	 0.8Q�6?   ._�5   
   �  � RowDefinitions 5      �� 5      $��25 �6    �� 5      $	��67* �6    .+�5      �� 
���   �$��0,1,0,0q�6)   $
��Left=�6C   $
��auto��6^   $��2��6l   $��Stretch=�6}   $	��577��6�   $��
5,30,0,0.4q�6�   ._�5      �� -   5        $��PostText��5      $
��Wrap=�6,   $��0,9.2,0,8.6q�6V   
���   ���6@   �� *Text+6k   5      �� 5      -   5        $��UserName��5      $
��Left=�6E   $��5,1,0,0q�6`   $	��Top=�6q   $
��auto��6�   
���   ���6$   �� *UserFullName+6�   �� 5      -   5        $��PubDate��5      $
��Left=�6@   $��	397,1,0,0q�6[   $	��Top=�6n   $	��185��6�   $��Right=�6�   
���   ���6#   �� *
SendTime+6�   � 5      $��Right=�6   $��26��6/   $��
0,0.9,10,0q�6;   $��2��6O   $	��Top=�6\   $
��auto��6t    � ColumnDefinitions 5      �� 5      $
��109* �6'   �� 5      $
��auto �6'   �� 5      $	��30* �6'   5      5       5!      5"      