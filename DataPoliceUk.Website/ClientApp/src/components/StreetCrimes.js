import React, { Component } from 'react';
import SimpleMap from './map';

export class StreetCrimes extends Component {
    displayName = StreetCrimes.name

    constructor(props) {
        super(props);
        this.state = {
            forces: [],
            force: null,
            boundaries: [],
            boundary: null,
            boundaryData: [],
            latitude: '',
            longitude: '',
            date: '',
            crimes: [],
            loading: true,
            changed: false
        };

        this.handleClick = this.handleClick.bind(this);
        this.handleForceChange = this.handleForceChange.bind(this);
        this.handleBoundaryChange = this.handleBoundaryChange.bind(this);
        this.handleInputChange = this.handleInputChange.bind(this);

        fetch('api/Forces')
            .then(response => response.json())
            .then(data => {
                this.setState({ forces: data, loading: false });
                //console.log(data);
            });
    }

    handleForceChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({ loading: true });

        this.setState({
            [name]: value
        });

        fetch('api/Neighbourhoods/' + value)
            .then(response => response.json())
            .then(data => {
                this.setState({ boundaries: data, loading: false });
                //console.log(data);
            });

        //console.log(value);
    }

    handleBoundaryChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });

        fetch('api/Neighbourhoods/' + this.state.force + "/" + value)
            .then(response => response.json())
            .then(data => {
                this.setState({ latitude: data.centre.latitude, loading: false });
                this.setState({ longitude: data.centre.longitude, loading: false });
                this.setState({ boundaryData: data, loading: false });
                //console.log(data);
            });

        //console.log(value);
    }

    handleInputChange(event) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });

        //console.log(value);
    }

    handleClick(event) {
        event.preventDefault();
        fetch('api/CrimesStreet/LatitudeLongitude/' + this.state.force + '/' + this.state.latitude + '/' + this.state.longitude + '/' + this.state.date)
            .then(response => response.json())
            .then(data => {
                this.setState({ crimes: data, changed: true });
                //console.log(data);
            });
    }

    static renderCrimes(crimes, latitude, longitude, date) {
        return (
            <div>
                <div style={{ width: '100%', height: '600px' }}>
                    <SimpleMap latitude={latitude} longitude={longitude} crimes={crimes} date={date} />
                    <div id="legend">
                        <h3>Legend</h3>
                        <ul>
                            <li className='red'>Violent Crime</li>
                            <li className='blue'>Public Order</li>
                            <li className='purple'>Criminal Damage</li>
                            <li className='darkgoldenrod'>Burglary</li>
                            <li className='green'>Other</li>
                        </ul>
                    </div>
                </div>
            </div>
        );
    };

    static createMarkup(html) {
        return { __html: html };
    }

    render() {
        let crimes = this.state.changed ? StreetCrimes.renderCrimes(this.state.crimes, this.state.latitude, this.state.longitude, this.state.date) : null;

        return (
            <div>
                <div className='row'>
                    <div className='col-md-12'>
                        <h1>Forces</h1>
                        <div className='row'>
                            <div className='col-xs-6'>
                                <select name='force' className='form-control' onChange={this.handleForceChange} value={this.state.value}>
                                    <option value=''>Please select...</option>
                                    {this.state.forces.map(force =>
                                        <option key={force.id} value={force.id}>{force.name}</option>
                                    )}
                                </select>
                            </div>
                            <div className='col-xs-6'>
                                <select name='boundary' className='form-control' onChange={this.handleBoundaryChange} value={this.state.value}>
                                    <option value=''>Please select...</option>
                                    {this.state.boundaries.map(boundary =>
                                        <option key={boundary.id} value={boundary.id}>{boundary.name}</option>
                                    )}
                                </select>
                            </div>
                        </div>
                    </div>
                </div>

                <div className='row'>
                    <div className='col-md-12'>
                        <h5>Filters:</h5>
                        <form className="form-inline">
                            <div className='row'>
                                <div className='col-xs-4'>
                                    <select name='date' className='form-control' onChange={this.handleInputChange} value={this.state.value}>
                                        <option value=''>Please select a date...</option>
                                        <option value='2019-01'>2019-01</option>
                                        <option value='2018-12'>2018-12</option>
                                        <option value='2018-11'>2018-11</option>
                                        <option value='2018-10'>2018-10</option>
                                        <option value='2018-09'>2018-09</option>
                                        <option value='2018-08'>2018-08</option>
                                        <option value='2018-07'>2018-07</option>
                                        <option value='2018-06'>2018-06</option>
                                        <option value='2018-05'>2018-05</option>
                                        <option value='2018-04'>2018-04</option>
                                        <option value='2018-03'>2018-03</option>
                                        <option value='2018-02'>2018-02</option>
                                        <option value='2018-01'>2018-01</option>
                                    </select>
                                </div>
                                <div className='col-xs-4'>
                                    <input type="text" name="latitude" className='form-control' placeholder='latitude' value={this.state.latitude} onChange={this.handleInputChange} />
                                </div>
                                <div className='col-xs-4'>
                                    <input type="text" name="longitude" className='form-control' placeholder='longitude' value={this.state.longitude} onChange={this.handleInputChange} />
                                </div>
                            </div>
                            <button onClick={this.handleClick} className='btn'>Submit</button>
                        </form>
                    </div>

                </div>

                <div className='row'>
                    <div className='col-md-12'>{crimes}</div>
                </div>

            </div>
        );
    }
}