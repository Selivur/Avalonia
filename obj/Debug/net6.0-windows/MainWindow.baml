   M S B A M L   `   `   `  ����C  ?Avalonia, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:AvaloniaAvalonia  5   	   9!clr-namespace:Avalonia.ViewModelsAvalonia.ViewModels  5   	       Avalonia.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Avalonia     5   	   0vm!clr-namespace:Avalonia.ViewModels     5   	   $	��600��5	   !   $
��1200��6.     � Title  6	   �� *Title+.��5      �  � ColumnDefinitions 5   
   �� 5      �� 5      $
��0.3* �6   �� 5      �� 5      $
��0.1* �6   �� 5      $��0.045* �6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��0.2* �6   �� 5      .+�5   
   �� -   5        $��Playlist_box��5   v   $��0��67      ListBoxTemplate1#���   6D   
�������$��Stretch=�6�   $��5��6�   ��6   �� *playlistList+ �� SelectedIndex 6�   �� *
selector+ � 	Resources 5      ��%�  &	        �� 5      .R�5      �  5      �� 5      $
��0.3* �6/   �� 5       �� 5!      $��2* �6/   .+�5#      �� $��50��6D   $��0��6O   ��6    �� *playlistImageUrl+6O   �� 5$      $��1��6C   $��Center=�6S   $
��Wrap=�6p   $��Center=�6�   $��16(�6�   $
��Bold"�6�   ��6$   �� *playlistName+6�   �� 5%      $��2��6I   $��Center=�6Y   $
��Wrap=�6v   $��Center=�6�   $��14(�6�   ��6$   �� *playlistDescription+6�   5&      5'      5(      5)      �� 5*   
   -   5         ��Name$ 	textBlock��5*      $��Center=�6'   $��1��6D   $
��Wrap=�6Q   $��Track��6e   $��Center=�6r   $
��Bold"�6�   $��16(�6�   �� 5+   
   -   5        $ 
textBlock1��5+      $��1��6(   $��Center=�68   $��1��6U   $
��Wrap=�6b   $��Artist��6v   $��Center=�6�   $
��Bold"�6�   $��16(�6�   �� 5,   
   -   5        $ 
textBlock2��5,      $��2��6(   $��Center=�68   $��1��6U   $
��Wrap=�6b   $��Album��6v   $��Center=�6�   $
��Bold"�6�   $��16(�6�   �� 5-   
   -   5        $ 
textBlock3��5-      $��3��6(   $��Center=�68   $��1��6U   $
��Wrap=�6b   $
��Time��6v   $��Center=�6�   $
��Bold"�6�   $��14(�6�   �� 5.   
   -   5        $��	Songs_box��5.   �     ListBoxTemplate2#���  63   $��Visible=�6e   $��2��6�   
�������$��Stretch=�6�   $��5��6�   ��6   �� *
songList+ 5/      ��%�  &	       �� 50      .R�51      �  52      �� 53      �� 54      $
��0.3* �6/   �� 55      �� 56      $
��0.1* �6/   .+�58      �� $��0��6;   $��Center=�6K   $
��Wrap=�6h   $��Center=�6|   $��14(�6�   ��6$   �� *name+6�   �� 59      $��1��6=   $��Center=�6M   $
��Wrap=�6j   $��Center=�6~   $��14(�6�   ��6$   �� *artist+6�   �� 5:      $��2��6<   $��Center=�6L   $
��Wrap=�6i   $��Center=�6}   $��14(�6�   ��6$   �� *album+6�   �� 5;      $��3��6>   $��Center=�6N   $
��Wrap=�6k   $��Center=�6   $��14(�6�   ��6$   �� *
duration+6�   5<      5=      5>      5?      5@      5A      