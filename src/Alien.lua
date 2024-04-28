--[[
    GD50
    Angry Birds

    Author: Colton Ogden
    cogden@cs50.harvard.edu
]]

Alien = Class {}

function Alien:init(world, type, x, y, userData)
    self.world = world
    self.type = type or 'square'
    self.hitted = false

    self.body = love.physics.newBody(self.world,
        x or math.random(VIRTUAL_WIDTH), y or math.random(VIRTUAL_HEIGHT - 35),
        'dynamic')

    -- different shape and sprite based on type passed in
    if self.type == 'square' then
        self.shape = love.physics.newRectangleShape(35, 35)
        self.sprite = math.random(5)
    else
        self.shape = love.physics.newCircleShape(17.5)
        self.sprite = 9
    end

    self.fixture = love.physics.newFixture(self.body, self.shape)

    self.fixture:setUserData(userData)

    -- used to keep track of despawning the Alien and flinging it
    self.launched = false
end

function Alien:special()
    -- alien = Alien(self.world, 'round', self.body:getX(), self.body:getY() - 30, 'Player')
    -- x, y = self.body:getLinearVelocity()
    -- alien.body:setLinearVelocity(x, y)
    -- alien.fixture:setRestitution(0.4)
    -- alien.body:setAngularDamping(1)

    -- alien = Alien(self.world, 'round', self.body:getX(), self.body:getY() + 30, 'Player')
    -- x, y = self.body:getLinearVelocity()
    -- alien.body:setLinearVelocity(x, y)
    -- alien.fixture:setRestitution(0.4)
    -- alien.body:setAngularDamping(1)
end

function Alien:render()
    love.graphics.draw(gTextures['aliens'], gFrames['aliens'][self.sprite],
        math.floor(self.body:getX()), math.floor(self.body:getY()), self.body:getAngle(),
        1, 1, 17.5, 17.5)
end
