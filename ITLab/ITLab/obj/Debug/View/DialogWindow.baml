   M S B A M L   `   `   `  ����@  <ITLab, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:ITLab.View
ITLab.View  5   	       ITLab.View.DialogWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:ITLab.View     5   	     � Title$  Диалог��5   	   $	��476��6   $	��660��6%    � WindowStyle$ 
ToolWindow=�61    � 
ResizeMode$ NoResize=�6J   .��5	      �  � RowDefinitions 5
   
   �� 5      $
��auto �6   $	��300��6*   �� 5      $
��auto �6   .+�5   
   �� $*��$Написать сообщение:��6   $
��Left=�6.   $	��Top=�6I   $��10,380.2,0,-330.6q�6a   $��1��6|   $	��634��6�   �� 5   
   -   5        $��TextBoxMessage��5      $
��Left=�6(   $��28��6C    �� TextWrapping$
 Wrap=�6O   $	��Top=�6d   $	��523��6|   $��9,409.2,0,-356.4q�6�   $��1��6�   �� 5   
   
���   �$��1q�6%   $
��Left=�69   $��1��6T   $��
10,6.2,0,0q�6_   $��1��6s   $	��Top=�6�   $	��634��6�   �� 5   
   -   5         �� 	IsDefault . $��0q�5   $   $��Отправить��60   $
��Left=�6D   $��537,405,0,0q�6_   $��1��6t   $	��Top=�6�   $	��106��6�   
�������$��32��6�   6�   �� 5   
   $	��363��6   $��0,12.2,-0.4,-292.8q�6$   $��1��6@   $	��Top=�6M   $��Stretch=�6e   .��5      � $	��624��6   .+�5      �� $��Center=�6   $	��624��67   ��6D   �� *MessagesList+��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � �� �� Value$ 5q�67   �� 5       � {� .  6:   5      ��5      �� 5      .R�5         ITLab.View.MessageView  5       5"      5#      5$      �� 5%   
   
���   �$��1q�6%   $
��Left=�69   $��1��6T   $��9,375.2,0,-301q�6_   $��1��6w   $	��Top=�6�   $	��634��6�   5&      5'      