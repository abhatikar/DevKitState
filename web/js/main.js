function init() {
    var app = new Vue({
        el: '#devkit',
        data: {
            functionAppName: '',
            reportedTwin: {},
            deviceId:'AZ3166',
            lastUpdated: '',
            userLEDState: 0,
            userLEDUpdateEndpoint: 'about:blank',
            loading: false,
            functionAppNameSet: false
        },
        methods: {
            getTwin: getTwin,
            getState: getState,
            updateUserLEDState: updateUserLEDState
        }
    });
}

function getTwin() {
    var scope = this;
    var timespan = new Date().getTime();
    var url = `https://${this.functionAppName}.azurewebsites.net/api/devkit-state?action=get&t=${timespan}`;
    this.$http.jsonp(url).then(function(data){
        return data.json();
    }).then(function (data){
        scope.loading = false;
        scope.reportedTwin = data.Reported;
        scope.userLEDState = data.Desired.userLEDState || 0;
        scope.lastUpdated = new Date(scope.reportedTwin.$metadata.$lastUpdated).toLocaleString('en-GB', {hour12: false}).replace(',', '');
    });
}

function updateUserLEDState() {
    var timespan = new Date().getTime();
    var state = this.userLEDState === 1 ? 0 : 1;
    this.userLEDUpdateEndpoint = `https://${this.functionAppName}.azurewebsites.net/api/devkit-state?action=set&state=${state}&t=${timespan}`;
    setTimeout(this.getTwin, 1000);
}

function getState() {
    if (!this.functionAppName)
    {
        alert('No function name found.');
        return;
    }
    this.functionAppNameSet = true;
    this.loading = true;
    setInterval(this.getTwin, 5000);
}

init();