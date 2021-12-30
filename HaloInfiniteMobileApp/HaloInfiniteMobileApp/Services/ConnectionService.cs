﻿using HaloInfiniteMobileApp.Interfaces;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;

namespace HaloInfiniteMobileApp.Services;

public class ConnectionService : IConnectionService
{
    private readonly IConnectivity _connectivity;

    public ConnectionService()
    {
        _connectivity = CrossConnectivity.Current;
        _connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
    }

    private void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        ConnectivityChanged?.Invoke(this, new ConnectivityChangedEventArgs() { IsConnected = e.IsConnected });
    }

    public bool IsConnected => _connectivity.IsConnected;

    public event ConnectivityChangedEventHandler ConnectivityChanged;
}