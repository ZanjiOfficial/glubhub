export function load_map(mapId, lat, lng, zoom, dotNetObject) {
    if (typeof L === 'undefined') {
        console.error('Leaflet not loaded');
        return;
    }

    const map = L.map(mapId).setView([lat, lng], zoom);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19,
        attribution: '&copy; OpenStreetMap contributors'
    }).addTo(map);

    let marker = null;

    // Handle user click
    map.on('click', function (e) {
        const { lat, lng } = e.latlng;

        if (marker) map.removeLayer(marker);
        marker = L.marker([lat, lng]).addTo(map);

        // Call Blazor component
        dotNetObject.invokeMethodAsync('SetCoordinates', lat, lng);
    });
}
