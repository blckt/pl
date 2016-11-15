export const register = (user) => ({ type: 'REGISTER', user });
export const logout = () => ({ type: 'LOGOUT' });
export const pingAuth = () => ({ type: 'PING_AUTH' });
